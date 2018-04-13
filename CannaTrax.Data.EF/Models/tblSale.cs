namespace CannaTrax.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSale")]
    public partial class tblSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSale()
        {
            tblSaleDetails = new HashSet<tblSaleDetail>();
            tblSalePayments = new HashSet<tblSalePayment>();
            tblSaleTaxes = new HashSet<tblSaleTax>();
        }

        public int ID { get; set; }

        public int? OrderNo { get; set; }

        [StringLength(50)]
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

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [StringLength(512)]
        public string Notes { get; set; }

        public bool? IsDeleted { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleDetail> tblSaleDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalePayment> tblSalePayments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleTax> tblSaleTaxes { get; set; }
    }
}
