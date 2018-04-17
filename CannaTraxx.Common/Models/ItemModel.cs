namespace CannaTraxx.Common.Models
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? Quantity { get; set; }
        public string PhotoPath { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
