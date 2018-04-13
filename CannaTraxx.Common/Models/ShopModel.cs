namespace CannaTraxx.Common.Models
{
    public class ShopModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StoreCode { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string LogoPath { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDefault { get; set; }
    }
}
