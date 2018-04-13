namespace CannaTraxx.Common.Models
{
    public class RoleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }
}
