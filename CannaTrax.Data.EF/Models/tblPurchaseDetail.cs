namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPurchaseDetail")]
    public partial class tblPurchaseDetail: IQueryableEntity
    {
        public int ID { get; set; }

        public int? PurchaseID { get; set; }

        public int? ItemID { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Amount { get; set; }

        public virtual tblItem tblItem { get; set; }

        public virtual tblPurchase tblPurchase { get; set; }
    }
}
