namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
