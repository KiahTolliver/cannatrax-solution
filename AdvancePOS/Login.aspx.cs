using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;

namespace AdvancePOS
{
    public partial class Login : System.Web.UI.Page
    {        
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        Helper.GeneralHelper dHelper = new Helper.GeneralHelper();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Focus();
                var setting = db.tblGeneralSettings.FirstOrDefault();
                if (setting != null)
                {
                    ltrLogo.Text = "<img src=\"" + setting.CompanyLogo + "\">";
                }
            }
        }

        protected void brnSubmit_Click(object sender, EventArgs e)
        {
            PnError.Visible=false;

            if (txtUserName.Text == "")
            {
                PnError.Visible=true;
                ltrMessage.Text = "Invalid login. No such user exists";
                return;
            }
            if (txtPassword.Text == "")
            {
                PnError.Visible=true;
                ltrMessage.Text = " Invalid login. No such user exists";
                return;
            }
            //Check username and password
            var login = db.tblUsers.FirstOrDefault(s => s.UserName == txtUserName.Text && s.Password == txtPassword.Text && s.IsActive == true && s.IsDeleted == false);
            if (login != null)
            {
                Session["UserID"] = Convert.ToString(login.ID);
                Session["RoleID"] = Convert.ToString(login.RoleID);
                if (login.ShopID != null)
                    Session["ShopID"] = Convert.ToString(login.ShopID);
                dHelper.LogAction("Successfully Login User " + login.UserName);
                if (Request.QueryString["return"] != null)
                    Response.Redirect(Request.QueryString["return"]);
                else
                    Response.Redirect("/Default.aspx");
            }
            else
            {
                PnError.Visible = true;
                ltrMessage.Text = "Invalid Login. Please try again with correct user ID and password.";
            }
        }
    }
}