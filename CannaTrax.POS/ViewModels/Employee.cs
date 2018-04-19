using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Employee
    {
        public int Id { get; set; }
        public int? RoleID { get; set; }
        public int? ShopID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Supervisor { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
    }
}