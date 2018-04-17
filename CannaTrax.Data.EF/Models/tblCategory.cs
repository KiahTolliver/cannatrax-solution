namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblCategory")]
    public partial class tblCategory:IQueryableEntity, IAuditableEntity
    {
        public int ID { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
