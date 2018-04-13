namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSupplier")]
    public partial class tblSupplier : IQueryableEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSupplier()
        {
            tblPurchases = new HashSet<tblPurchase>();
        }

        public int ID { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(512)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(512)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(50)]
        public string SupplierType { get; set; }

        public bool? IsDeleted { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchase> tblPurchases { get; set; }
    }
}
