using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Sale
    {
        public int ID { get; set; }
        public int? OrderNo { get; set; }
        public string RefNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerID { get; set; }
        public int? ShopID { get; set; }
        public int? TotalItem { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Change { get; set; }
        public string Status { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }
    }
}