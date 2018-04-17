﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.Models
{
    public class PurchaseDetailModel
    {
        public int ID { get; set; }
        public int? PurchaseID { get; set; }
        public int? ItemID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Amount { get; set; }

    }
}
