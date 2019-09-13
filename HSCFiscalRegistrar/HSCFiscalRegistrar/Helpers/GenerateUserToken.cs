﻿using System;

namespace HSCFiscalRegistrar.DTO.UserModel
{
    public static class GenerateUserToken
    {
        private static Guid _guid;
        public static Guid GetGuidKey()
        {
            return _guid = Guid.NewGuid();
        }
        public static DateTime TimeCreation()
        {
            return DateTime.Now;
        }
    }
}