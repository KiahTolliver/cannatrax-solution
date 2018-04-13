namespace CannaTraxx.Common.Models
{
    public class ModuleModel
    {
        public int ID { get; set; }
        public int? ParentModuleID { get; set; }
        public int? DisplayOrder { get; set; }
        public string ModuleName { get; set; }
        public string PageIcon { get; set; }
        public string PageUrl { get; set; }
        public string PageSlug { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
