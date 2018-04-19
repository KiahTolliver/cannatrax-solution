using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Dashboard
    {
        public IEnumerable<Employee> EmployeeList { get; set; }
        public IEnumerable<Sale> SalesList { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
        public IEnumerable<Purchase> PurchaseList { get; set; }




    }
}