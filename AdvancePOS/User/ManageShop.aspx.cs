using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using System.IO;
using AdvancePOS.Helper;

namespace AdvancePOS.User
{
    public partial class ManageShop : Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateShop();
                dHelper.LogAction("User View Shop Master");
            }
        }

        private void PopulateShop()
        {
            var shop = db.sp_GetShop().ToList();
            gvShop.DataSource = shop;
            gvShop.DataBind();
            if (shop.Count() > 0)
            {
                gvShop.UseAccessibleHeader = true;
                gvShop.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //Save and Update Shop
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());
            if (FileUploadLogo.HasFile)
            {
                if (HiddenID.Value != "")
                {
                    String logoPhoto = Server.MapPath("~/" + HiddenFilename.Value);
                    if (File.Exists(logoPhoto))
                        File.Delete(logoPhoto);
                }
                String fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUploadLogo.FileName);
                HiddenFilename.Value = "/Images/StoreLogo/" + fileName;
                FileUploadLogo.SaveAs(Server.MapPath("~/Images/StoreLogo/" + fileName));
            }
            if (HiddenID.Value == "")
            {
                if (HiddenFilename.Value == "")
                    HiddenFilename.Value = "/Images/default.jpg";
                db.sp_StoreAdd(txtName.Text, txtStoreCode.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, HiddenFilename.Value, UserID, UserID);
                dHelper.LogAction("User Add Shop " + txtName.Text);
            }
            else
            {
                db.sp_StoreUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, txtStoreCode.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, HiddenFilename.Value, UserID);
                dHelper.LogAction("User Update Shop " + txtName.Text);
            }
            PopulateShop();
            SetDefaultValue();
        }

        //Edit Shop Details
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var store = db.tblShops.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (store != null)
            {
                if (store.IsDefault == true)
                {
                    PnError.Visible = true;
                    ltrError.Text = "Enable to edit default shop.!!!";                    
                }
                else
                {
                    ltrTitle.Text = "Edit Shop : " + store.Name;
                    txtName.Text = store.Name;
                    txtStoreCode.Text = store.StoreCode;
                    txtEmail.Text = store.Email;
                    txtPhone.Text = store.PhoneNo;
                    txtAddress.Text = store.Address;                    
                    HiddenFilename.Value = store.LogoPath;

                    String logoPhoto = Server.MapPath("~/" + store.LogoPath);
                    if (File.Exists(logoPhoto))
                        ImagePhoto.ImageUrl = store.LogoPath;
                    else
                        ImagePhoto.ImageUrl = "/Images/StoreLogo/default.jpg";

                    dHelper.LogAction("User Edit Shop " + txtName.Text);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);
                }
                PopulateShop();                
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvShop').DataTable();", true);
                upModal.Update();
            }
        }

        //Delete Shop
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var store = db.tblShops.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (store != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    if (store.IsDefault == true)
                    {
                        PnError.Visible = true;
                        ltrError.Text = "delete Disable to default shop.!!!";
                    }
                    else
                    {
                        store.IsDeleted = true;
                        db.SubmitChanges();
                        dHelper.LogAction("User Delete Shop " + store.Name);
                    }
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "disable delete action in demo.!!!";
                }
                PopulateShop();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvShop').DataTable();", true);
            }   
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            PopulateShop();
            HiddenID.Value = "";
            ltrTitle.Text = "Add Shop";
            txtName.Text = "";
            txtStoreCode.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvShop').DataTable();", true);
            upModal.Update();
        }
    }
}