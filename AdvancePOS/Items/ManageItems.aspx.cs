using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;
using System.IO;

namespace AdvancePOS.Items
{
    public partial class ManageItems : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateItem();
                PopulateCategory();
                dHelper.LogAction("User View Item Master");
            }
        }

        private void PopulateCategory()
        {
            var category = db.sp_GetCategory();
            ddlCategory.DataSource = category;
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
            ddlCategory.SelectedIndex = 0;
        }

        private void PopulateItem()
        {
            var items = db.sp_GetItem().ToList();
            gvItem.DataSource = items;
            gvItem.DataBind();
            if (items.Count() > 0)
            {
                gvItem.UseAccessibleHeader = true;
                gvItem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvItem').DataTable();", true);
        }

        //Get Item Stock
        protected string GetItemStock(string ItemID)
        {
            if (ItemID != "")
                return dHelper.GetItemStock(Convert.ToInt32(ItemID));
            else
                return "";
        }

        //Save and Update Item
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ltrCode.Text = "";
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());           

            string base64 = Request.Form["imgCropped"];
            if (base64.Length > 0)
            {
                if (HiddenID.Value != "")
                {
                    String logoPhoto = Server.MapPath("~/" + HiddenFilename.Value);
                    if (File.Exists(logoPhoto))
                        File.Delete(logoPhoto);
                }

                byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
                String fileName = Guid.NewGuid().ToString() + ".png";
                using (FileStream stream = new FileStream(Server.MapPath("~/Images/Item/" + fileName), FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
                HiddenFilename.Value = "/Images/Item/" + fileName;
            }

            if (HiddenID.Value == "")
            {
                if (HiddenFilename.Value == "")
                    HiddenFilename.Value = "/Images/default.jpg";
                var item = db.tblItems.FirstOrDefault(s => s.ItemCode.ToLower() == txtItemCode.Text);
                if (item != null)
                {
                    ltrCode.Text = "<span style=\"color: red;\">Duplicate item code. !!!</span>";
                    PopulateItem();
                }
                else
                {
                    db.sp_ItemAdd(txtName.Text, txtItemCode.Text, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToDecimal(txtPurchasePrice.Text),
                        Convert.ToDecimal(txtSellingPrice.Text), Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtQty.Text), HiddenFilename.Value, UserID, UserID);
                    dHelper.LogAction("User Add Item " + txtName.Text);
                    SetDefaultValue();
                }
            }
            else
            {
                var item = db.tblItems.FirstOrDefault(s => s.ItemCode.ToLower() == txtItemCode.Text && s.ID != Convert.ToInt32(HiddenID.Value));
                if (item != null)
                {
                    ltrCode.Text = "<span style=\"color: red;\">Duplicate item code. !!!</span>";
                    PopulateItem();
                }
                else
                {
                    db.sp_ItemUpdate(Convert.ToInt32(HiddenID.Value), txtName.Text, txtItemCode.Text, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToDecimal(txtPurchasePrice.Text),
                        Convert.ToDecimal(txtSellingPrice.Text), Convert.ToDecimal(txtDiscount.Text),Convert.ToDecimal(txtQty.Text), HiddenFilename.Value, UserID);
                    dHelper.LogAction("User Update Item " + txtName.Text);
                    SetDefaultValue();
                }
            }
        }

        //Edit Item Details
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var item = db.tblItems.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (item != null)
            {
                ltrTitle.Text = "Edit Item : " + item.Name;
                txtName.Text = item.Name;
                txtItemCode.Text = item.ItemCode;
                ddlCategory.SelectedValue = item.CategoryID.ToString();
                txtPurchasePrice.Text = item.PurchasePrice.ToString();
                txtSellingPrice.Text = item.SellingPrice.ToString();
                txtDiscount.Text = item.DiscountRate.ToString();                
                HiddenFilename.Value = item.PhotoPath;
                txtQty.Text = item.Quantity.ToString();

                String logoPhoto = Server.MapPath("~/" + item.PhotoPath);
                if (File.Exists(logoPhoto))
                    ImagePhoto.ImageUrl = item.PhotoPath;
                else
                    ImagePhoto.ImageUrl = "/Images/default.jpg";

                dHelper.LogAction("User Edit Item " + txtName.Text);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);
            }
            PopulateItem();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvItem').DataTable();", true);
            upModal.Update();

        }

        //Delete Shop
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            PnError.Visible = false;
            LinkButton l = (LinkButton)sender;

            var item = db.tblItems.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (item != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                {
                    item.IsDeleted = true;
                    db.SubmitChanges();
                    dHelper.LogAction("User Delete Item " + item.Name);
                }
                else
                {
                    PnError.Visible = true;
                    ltrError.Text = "disable delete action in demo.!!!";
                }   
                PopulateItem();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvItem').DataTable();", true);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            PopulateItem();
            ltrCode.Text = "";
            HiddenID.Value = "";
            ltrTitle.Text = "Add Item";
            txtName.Text = "";
            txtItemCode.Text = "";
            txtPurchasePrice.Text = "";
            txtSellingPrice.Text = "";
            txtDiscount.Text = "";
            txtQty.Text = "";
            ddlCategory.SelectedIndex = 0;
            ImagePhoto.ImageUrl = "";
            HiddenFilename.Value = "";
           
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvItem').DataTable();", true);
            upModal.Update();
        }
    }
}