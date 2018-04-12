using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS.Purchase
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        Helper.GeneralHelper dHelper = new Helper.GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulatePurchase();
                dHelper.LogAction("User View Purchase History");
            }
        }

        private void PopulatePurchase()
        {
            var purchase = db.sp_GetPurchase().ToList();
            gvPurchase.DataSource = purchase;
            gvPurchase.DataBind();
            if (purchase.Count() > 0)
            {
                gvPurchase.UseAccessibleHeader = true;
                gvPurchase.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvPurchase').DataTable();", true);
        }
    }
}