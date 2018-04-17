namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblSalePayment")]
    public partial class tblSalePayment : IQueryableEntity
    {
        public int ID { get; set; }

        public int? SaleID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        [StringLength(50)]
        public string PaymentMode { get; set; }

        public decimal? Amount { get; set; }

        public virtual tblSale tblSale { get; set; }
    }
}
