using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public int ItemCode { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public double RetailPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public int Quantity { get; set; }
        public string PhotoPath {get;set;}
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set;}
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }



        
    }
}