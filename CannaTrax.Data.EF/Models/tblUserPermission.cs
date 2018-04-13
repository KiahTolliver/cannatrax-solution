namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblUserPermission")]
    public partial class tblUserPermission:IQueryableEntity
    {
        public int ID { get; set; }

        public int? ModuleID { get; set; }

        public int? RoleID { get; set; }

        public virtual tblModule tblModule { get; set; }

        public virtual tblRole tblRole { get; set; }
    }
}
