using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS
{
    public partial class _Default : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                PopulateDashboard();
        }

        private void PopulateDashboard()
        {
            //Get all sales
            var sales = db.sp_GetSaleHistory(null,null).ToList();
            if (sales.Count() > 0)
            {
                ltrOrder.Text = sales.Count().ToString();
                ltrTotalSale.Text = sales.Sum(s => s.NetAmount).ToString();
            }
            //Get all Items
            var items = db.sp_GetItem().ToList();
            if (items.Count() > 0)
                ltrProducts.Text = items.Count().ToString();

            //Get Today Sales
            var Todaysales = sales.Where(s => s.OrderDate.Value.Date == DateTime.Now.Date).Sum(s=>s.NetAmount);
            if (Todaysales > 0)
                ltrTodaySale.Text = Todaysales.ToString();
        }
    }
}
