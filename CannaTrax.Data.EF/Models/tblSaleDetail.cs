namespace CannaTrax.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSaleDetail")]
    public partial class tblSaleDetail
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
