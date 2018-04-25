using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModels
{
    public class POS
    {
        IEnumerable<Product> ProductList { get; }
        Sale NewOrder { get; set; }
    }
}