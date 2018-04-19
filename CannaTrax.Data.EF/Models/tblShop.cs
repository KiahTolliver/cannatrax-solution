namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblShop")]
    public partial class tblShop : IQueryableEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
      

        public int ID { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(50)]
        public string StoreCode { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(512)]
        public string Email { get; set; }

        [StringLength(512)]
        public string LogoPath { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsDefault { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

    }
}
