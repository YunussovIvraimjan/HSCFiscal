﻿using System;

namespace HSCFiscalRegistrar.DTO.UserModel
{
    public class UserChangePassword : UserDTO
    {
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}