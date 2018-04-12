﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string CompanyLogoPath { get; set; }
        public string Currency { get; set; }
    }
}