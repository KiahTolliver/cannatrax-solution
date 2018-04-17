namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblUser")]
    public partial class tblUser : IQueryableEntity, IAuditableEntity
    {
        public int ID { get; set; }

        public int? RoleID { get; set; }

        public int? ShopID { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [StringLength(100)]
        public string Supervisor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(512)]
        public string PhotoPath { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(512)]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsDefault { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public virtual tblRole tblRole { get; set; }

        public virtual tblShop tblShop { get; set; }
    }
}
