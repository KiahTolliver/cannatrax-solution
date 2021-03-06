namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblSaleDetail")]
    public partial class tblSaleDetail : IQueryableEntity
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

        public virtual tblItem tblItem { get; set; }

        public virtual tblSale tblSale { get; set; }
    }
}
