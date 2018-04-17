using System;

namespace CannaTraxx.Common.Models
{
    public class PurchaseModel
    {
        public int ID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Payment { get; set; }
        public string PaidBy { get; set; }
        public string Note { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
