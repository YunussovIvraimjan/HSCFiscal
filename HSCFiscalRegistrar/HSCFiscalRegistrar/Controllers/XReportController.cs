﻿using System;
using System.Linq;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.OfdRequests;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO.XReport;
using Models.DTO.XReport.KkmResponse;
using Newtonsoft.Json;
using Serilog;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class XReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly GenerateErrorHelper _errorHelper;

        public XReportController(ApplicationContext applicationContext, UserManager<User> userManager, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] KkmRequest request)
        {
            try
            {
                Log.Information("XReport|Post");
                Log.Information($"X-Отчет: {request.Token}");
                
                var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
                var kkm = _applicationContext.Kkms.First(k => k.Id == user.KkmId);
                var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id && s.CloseDate == DateTime.MinValue);
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                var merch = _userManager.Users.FirstOrDefault(u => u.Id == kkm.UserId);
                var response = new XReportKkmResponse(shiftOperations, operations, merch, kkm, shift);
                if (kkm == null) return Json( _errorHelper.GetErrorRequest(3));
                kkm.ReqNum += 1;
                _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                _applicationContext.SaveChangesAsync();
                var xReportOfdRequest = new OfdXReport();
                xReportOfdRequest.Request(kkm, merch);

                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return Json(e.Message);
            }
        }
    }
}