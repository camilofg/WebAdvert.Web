﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdvert.Web.Models.Accounts
{
    public class ResetModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
    }
}
