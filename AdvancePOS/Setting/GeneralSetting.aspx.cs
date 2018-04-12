using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;
using System.IO;

namespace AdvancePOS.Setting
{
    public partial class GeneralSetting : Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Update"] != null)
                {
                    pnMessage.Visible = true;
                    Session.Remove("Update");
                } 

                var setting = db.tblGeneralSettings.FirstOrDefault();
                if (setting != null)
                {
                    txtCompanyName.Text = setting.CompanyName;
                    txtAddress.Text = setting.Address;
                    txtPhoneNo.Text = setting.PhoneNo;
                    txtEmail.Text = setting.Email;
                    txtWebsite.Text = setting.Website;
                    txtCurrencyCode.Text = setting.CurrencyCode;
                    ImagePhoto.ImageUrl = setting.CompanyLogo;
                    HiddenFilename.Value = setting.CompanyLogo;
                    dHelper.LogAction("User Edit General Setting. ");
                }
            }
        }

         //Save and Update Setting
        protected void btnSave_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            if (GeneralHelper.IsDeleteEnable == false)
            {              
                PnError.Visible = true;
                ltrError.Text = "disable delete action in demo.!!!";
                return;
            }
            var setting = db.tblGeneralSettings.FirstOrDefault();
            if (setting != null)
            {
                setting.CompanyName = txtCompanyName.Text;
                setting.Address = txtAddress.Text;
                setting.PhoneNo = txtPhoneNo.Text;
                setting.Email = txtEmail.Text;
                setting.Website = txtWebsite.Text;
                setting.CurrencyCode = txtCurrencyCode.Text;                           
                if (FileUploadProfile.HasFile)
                {
                    String logoPhoto = Server.MapPath("~/" + HiddenFilename.Value);
                    if (File.Exists(logoPhoto))
                        File.Delete(logoPhoto);

                    String fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUploadProfile.FileName);
                    HiddenFilename.Value = "/Images/StoreLogo/" + fileName;
                    FileUploadProfile.SaveAs(Server.MapPath("~/Images/StoreLogo/" + fileName));
                    setting.CompanyLogo = HiddenFilename.Value;
                }
                db.SubmitChanges();
                dHelper.LogAction("User Update General Setting ");
                Session["Update"] = "Update";
                Response.Redirect(Request.Path);
            }
        }
    }
}