using System;

namespace CannaTraxx.Common.Models
{
    public class SalePaymentModel
    {
        public int ID { get; set; }
        public int? SaleID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Amount { get; set; }
    }
}
