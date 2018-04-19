using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Purchase
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int TotalItems { get; set; }
        public double TotalAmount { get; set; }
        public double Payment { get; set; }
        public string PaymentType { get; set; }
        public string Notes { get; set; }
    }
}