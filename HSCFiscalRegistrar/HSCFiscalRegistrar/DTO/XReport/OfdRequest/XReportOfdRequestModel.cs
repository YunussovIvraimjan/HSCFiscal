﻿using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.DTO.XReport.OfdRequest
{
    public class XReportOfdRequestModel
    {
        public CommandTypeEnum Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public Service Service { get; set; }
        public Report Report { get; set; }

        public XReportOfdRequestModel(Kkm kkm, Org org)
        {
            Command = CommandTypeEnum.COMMAND_REPORT;
            DeviceId = kkm.DeviceId;
            ReqNum = kkm.ReqNum;
            Token = kkm.OfdToken;
            var regInfo = new RegInfo(org, kkm);
            Service = new Service(regInfo);
            Report = new Report(ReportTypeEnum.REPORT_X, GetDateTime(), false);
        }

        private DateTime GetDateTime()
        {
            return new DateTime
            {
                Date = new Date
                {
                    Day = System.DateTime.Now.Day,
                    Month = System.DateTime.Now.Month,
                    Year = System.DateTime.Now.Year
                },
                Time = new Time
                {
                    Hour = System.DateTime.Now.Hour,
                    Minute = System.DateTime.Now.Minute,
                    Second = System.DateTime.Now.Second
                }
            };
        }
    }
}