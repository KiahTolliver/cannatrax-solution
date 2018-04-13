using System;

namespace CannaTraxx.Common.Models
{
    public class UserLogModel
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string Message { get; set; }
        public string MoreInfo { get; set; }
        public DateTime? LogTime { get; set; }
        public string IPAddress { get; set; }
    }
}
