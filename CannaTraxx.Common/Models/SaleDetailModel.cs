﻿namespace CannaTraxx.Common.Models
{
    public class SaleDetailModel
    {
        public int ID { get; set; }
        public int? SaleID { get; set; }
        public int? ItemID { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
    }
}
