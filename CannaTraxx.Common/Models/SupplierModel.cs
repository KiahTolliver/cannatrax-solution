namespace CannaTraxx.Common.Models
{
    public class SupplierModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SupplierType { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
