using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMarijuana { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}