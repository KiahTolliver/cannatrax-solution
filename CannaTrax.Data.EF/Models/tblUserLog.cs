namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUserLog")]
    public partial class tblUserLog : IQueryableEntity
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(512)]
        public string Message { get; set; }

        [StringLength(512)]
        public string MoreInfo { get; set; }

        public DateTime? LogTime { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }
    }
}
