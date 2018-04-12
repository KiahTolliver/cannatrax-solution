using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        Helper.GeneralHelper dHelper = new Helper.GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("/Login.aspx?return=" + Request.RawUrl);
                else
                {
                    var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == Convert.ToInt32(Session["UserID"]));
                    if (userInfo != null)
                    {
                        if (userInfo.ShopID != null)
                            Session["ShopID"] = Convert.ToString(userInfo.ShopID);
                        ltrUserName.Text = userInfo.FirstName + " " + userInfo.LastName;
                        ltrUserName1.Text = userInfo.FirstName + " " + userInfo.LastName;
                        ltrDepartment.Text = userInfo.Department;
                        ImageProfile.ImageUrl = userInfo.PhotoPath;
                        ImageProfile1.ImageUrl = userInfo.PhotoPath;
                    }
                    var setting = db.tblGeneralSettings.FirstOrDefault();
                    if (setting != null)                    
                        ltrLogo.Text = "<img width=\"100%\" src=\"" + setting.CompanyLogo + "\">";                    
                }
            }
        }

        protected void LinkLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            dHelper.LogAction("Successfully LogOut into Account." + ltrUserName.Text);
            Response.Redirect("/Login.aspx");
        }
    }
}
