using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Purchase
{
    public partial class ManagePurchase : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        Helper.AdvancePOS sp = new Helper.AdvancePOS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCategory();
                PopulateItems();
                Session.Remove("Purchase");
                PopulateSupplier();                
            }
        }

        private void PopulateSupplier()
        {
            ddlSupplier.DataSource = db.sp_GetSupplier().ToList();
            ddlSupplier.DataValueField = "ID";
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataBind();
        }

        //Get All Items
        private void PopulateItems()
        {
            var items = db.sp_GetItem().ToList();
            RpItems.DataSource = items;
            RpItems.DataBind();

            ddlProduct.DataSource = items;
            ddlProduct.DataValueField = "ID";
            ddlProduct.DataTextField = "Name";
            ddlProduct.DataBind();
        }

        //Get All Category
        private void PopulateCategory()
        {
            var category = db.sp_GetCategory().ToList();
            ddlCategory.DataSource = category;
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
        }

        //Get Amount With Currency
        protected string GetAmount(string PurchasePrice)
        {
            if (PurchasePrice != "")
                return PurchasePrice + " " + dHelper.GetCurrency();
            else
                return "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Session.Remove("Purchase");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.select2').select2();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#MainContent_txtDate').datepicker();", true);
            SetDefaultValue();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            Helper.ShoppingCart cart = null;
            System.Data.Common.DbTransaction transaction;
            db.Connection.Open();
            transaction = db.Connection.BeginTransaction();
            db.Transaction = transaction;
            int? PurchaseID = 1;
            Decimal TotalItem = 0, TotalAmount = 0;

            TotalItem =Convert.ToDecimal(sp.GetPurchaseItem()[2]);
            TotalAmount = Convert.ToDecimal(sp.GetPurchaseItem()[1]);
            db.sp_PurchaseAdd(Convert.ToInt32(ddlSupplier.SelectedValue), Convert.ToDateTime(txtDate.Text), TotalItem, TotalAmount, Convert.ToDecimal(txtPayment.Text), ddlPaidBy.SelectedValue, txtNotes.Text, UserID, ref PurchaseID);
            if (Session["Purchase"] != null)
                cart = HttpContext.Current.Session["Purchase"] as Helper.ShoppingCart;
            if (cart != null)
            {
                foreach (var t in cart.Items)
                {
                    var product = db.tblItems.FirstOrDefault(s => s.ID == t.ProductID);
                    if (product != null)
                    {
                        Decimal Total = (product.PurchasePrice.Value * t.Quantity);
                        db.sp_PurchaseDetailAdd(PurchaseID, t.ProductID, t.Quantity, product.PurchasePrice, 0, Total);                      
                    }
                }
            }

            dHelper.LogAction("User Add Purchase ID " + PurchaseID);
            
            db.SubmitChanges();
            transaction.Commit();
            SetDefaultValue();
            Session.Remove("Purchase");
        }
     
        public void SetDefaultValue()
        {            
            HiddenID.Value = "";
            ltrTitle.Text = "Make Payment";
            txtPayment.Text = "";
            txtNotes.Text = "";
            txtDate.Text = "";            

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.select2').select2();", true); 
            upModal.Update();
        }

        //protected string GetAmount(string ItemID)
        //{
        //    if (ItemID != "")
        //        return dHelper.GetItemSellingPrice(Convert.ToInt32(ItemID)) + " " + dHelper.GetCurrency();            
        //    else
        //        return "";
        //}
    }
}