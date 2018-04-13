namespace CannaTrax.Data.EF
{
    using CannaTrax.Data.EF.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSaleTax")]
    public partial class tblSaleTax : IQueryableEntity
    {
        public int ID { get; set; }

        public int? SaleID { get; set; }

        public int? TaxID { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? TaxAmount { get; set; }

        public virtual tblSale tblSale { get; set; }

        public virtual tblTax tblTax { get; set; }
    }
}
