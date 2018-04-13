namespace CannaTrax.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTax")]
    public partial class tblTax
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTax()
        {
            tblSaleTaxes = new HashSet<tblSaleTax>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? TaxRate { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public int? InsertedBy { get; set; }

        public DateTime? InsertedDate { get; set; }

        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSaleTax> tblSaleTaxes { get; set; }
    }
}
