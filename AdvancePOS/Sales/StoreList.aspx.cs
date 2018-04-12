using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS.Sales
{
    public partial class StoreList : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        Helper.GeneralHelper dHelper = new Helper.GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dHelper.LogAction("User View Store List ");
                var shop = db.sp_GetShop().ToList();
                if (Session["UserID"] != null)
                {
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == UserID);
                    if (userInfo != null)
                    {
                        if (userInfo.tblRole.IsSuperAdmin == false)
                            shop = shop.Where(s => s.ID == userInfo.ShopID).ToList();
                    }
                }
                RpStore.DataSource = shop;
                RpStore.DataBind();
            }
        }

         //Select Store
        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            Session["ShopID"] = l.CommandArgument.ToString();
            Response.Redirect("/Sales/ManageSale.aspx");
        }
    }
}