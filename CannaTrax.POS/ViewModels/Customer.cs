using CannaTrax.POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set;}
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMedical { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public List<Sale> PastOrders { get; set; }
    }
}