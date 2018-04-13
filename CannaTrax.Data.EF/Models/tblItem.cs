namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblItem")]
    public partial class tblItem: IQueryableEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblItem()
        {
            tblPurchaseDetails = new HashSet<tblPurchaseDetail>();
            tblSaleDetails = new HashSet<tblSaleDetail>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ItemCode { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? DiscountRate { get; set; }

        public decimal? Quantity { get; set; }

        [StringLength(512)]
        public string PhotoPath { get; set; }

        public bool? IsDeleted { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseDetail> tblPurchaseDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleDetail> tblSaleDetails { get; set; }
    }
}
