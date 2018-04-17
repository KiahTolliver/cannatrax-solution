using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.Models
{
    public class TaxModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? TaxRate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
