namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblCustomer")]
    public partial class tblCustomer:IQueryableEntity, IAuditableEntity
    {
        public int ID { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(512)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
