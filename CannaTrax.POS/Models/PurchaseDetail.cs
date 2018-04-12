using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.Models
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double PreDiscountAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal PostDiscountAmount { get; set; }

    }
}