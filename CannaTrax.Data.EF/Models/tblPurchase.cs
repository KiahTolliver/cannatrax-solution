namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblPurchase")]
    public partial class tblPurchase: IQueryableEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPurchase()
        {
            tblPurchaseDetails = new HashSet<tblPurchaseDetail>();
        }

        public int ID { get; set; }

        public int? SupplierID { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal? TotalItem { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? Payment { get; set; }

        [StringLength(50)]
        public string PaidBy { get; set; }

        [StringLength(512)]
        public string Note { get; set; }

        public bool? IsDeleted { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public virtual tblSupplier tblSupplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseDetail> tblPurchaseDetails { get; set; }
    }
}
