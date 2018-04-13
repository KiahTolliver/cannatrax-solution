namespace CannaTrax.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGeneralSetting")]
    public partial class tblGeneralSetting
    {
        public int ID { get; set; }

        [StringLength(512)]
        public string CompanyName { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(512)]
        public string PhoneNo { get; set; }

        [StringLength(52)]
        public string Email { get; set; }

        [StringLength(512)]
        public string Website { get; set; }

        [StringLength(512)]
        public string CompanyLogo { get; set; }

        [StringLength(50)]
        public string CurrencyCode { get; set; }
    }
}
