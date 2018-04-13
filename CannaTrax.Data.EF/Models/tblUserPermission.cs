namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
