using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS.Report
{
    public partial class ItemStock : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateItem();
            }
        }

        private void PopulateItem()
        {
            var item = db.sp_GetItemStock(null).ToList();
            gvItem.DataSource = item;
            gvItem.DataBind();
            if (item.Count() > 0)
            {
                gvItem.UseAccessibleHeader = true;
                gvItem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvItem').DataTable();", true);
        }

        //Get Item Stock
        protected string GetBalance(string OpeningBalance, string Inwards, string Outwards)
        {
            return (Convert.ToDecimal(OpeningBalance) + Convert.ToDecimal(Inwards) - Convert.ToDecimal(Outwards)).ToString("0");
        }
    }
}