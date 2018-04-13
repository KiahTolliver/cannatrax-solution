namespace CannaTrax.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblModule")]
    public partial class tblModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblModule()
        {
            tblUserPermissions = new HashSet<tblUserPermission>();
        }

        public int ID { get; set; }

        public int? ParentModuleID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(100)]
        public string ModuleName { get; set; }

        [StringLength(50)]
        public string PageIcon { get; set; }

        [StringLength(100)]
        public string PageUrl { get; set; }

        [StringLength(512)]
        public string PageSlug { get; set; }

        public bool? IsShow { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserPermission> tblUserPermissions { get; set; }
    }
}
