using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Sales
{
    public partial class ManageSale : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        Helper.AdvancePOS sp = new Helper.AdvancePOS();
        Helper.ShoppingCart cart = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCategory();
                PopulateItems();
                Session.Remove("Sale");
                PopulateCustomer();

                if (Session["ShopID"] == null)
                    Response.Redirect("/Sales/StoreList.aspx");
                if (Session["Hold"] != null)
                {
                    PnSuccess.Visible = true;
                    Session.Remove("Hold");
                }
                else
                    PnSuccess.Visible = false;

                if (Request.QueryString["SaleID"] != null)
                {
                    var sale = db.tblSales.FirstOrDefault(s => s.ID ==Convert.ToInt32(dHelper.Decrypt(Request.QueryString["SaleID"].ToString())));
                    if (sale != null)
                    {
                        ddlCustomer.SelectedValue = sale.CustomerID.ToString();
                        txtHoldRef.Text = sale.RefNumber;
                        HiddenOrderNo.Value = sale.OrderNo.ToString();

                        var saleDetail = db.tblSaleDetails.Where(s => s.SaleID == sale.ID);

                        cart = new Helper.ShoppingCart();
                        foreach (var s in saleDetail)
                        {
                            ShoppingCartItem items = new ShoppingCartItem();
                            items.ProductID = s.ItemID.Value;
                            items.Quantity = s.Quantity.Value;                            
                            cart.AddItem(items);                            
                        }
                        HttpContext.Current.Session["Sale"] = cart;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Edit", "GetOpenedBillDetails();", true);
                    }
                }                
            }
        }

        private void PopulateCustomer()
        {
            ddlCustomer.DataSource = db.sp_GetCustomer().ToList();
            ddlCustomer.DataValueField = "ID";
            ddlCustomer.DataTextField = "Name";
            ddlCustomer.DataBind();
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
        protected string GetAmount(string ItemID)
        {
            if (ItemID != "")
                return dHelper.GetItemSellingPrice(Convert.ToInt32(ItemID)) + " " + dHelper.GetCurrency();
            else
                return "";
        }

        //Get Item Stock
        protected string GetItemStock(string ItemID)
        {
            if (ItemID != "")
                return dHelper.GetItemStock(Convert.ToInt32(ItemID));
            else
                return "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Button btnID = (Button)sender;
            int UserID = 0;
            if (Session["UserID"] != null)
                UserID = Convert.ToInt32(Session["UserID"].ToString());

            Helper.ShoppingCart cart = null;
            System.Data.Common.DbTransaction transaction;
            db.Connection.Open();
            transaction = db.Connection.BeginTransaction();
            db.Transaction = transaction;
            int? SaleID = 1;
            Decimal TotalItem = 0, NetAmount = 0, SubTotal = 0, TotalTax = 0, Change = 0;

            TotalItem = Convert.ToDecimal(sp.GetSaleItem().TotalItem);
            SubTotal = Convert.ToDecimal(sp.GetSaleItem().SubTotal);
            NetAmount = Convert.ToDecimal(sp.GetSaleItem().NetAmount) - Convert.ToDecimal(txtDiscount.Text);
            TotalTax = Convert.ToDecimal(sp.GetSaleItem().TotalTax);
            Change = Convert.ToDecimal(txtPayment.Text) - NetAmount;
            
            String Status = "Paid";
            if (txtPayment.Text == "0")
                Status = "UnPaid";
            else if (NetAmount > Convert.ToDecimal(txtPayment.Text))
            {
                Status = "Partial Payment";
                Change = 0;
            }

            //Set Order Status
            String OrderStatus = "POS";
            if (btnID.ID == "btnHold")
                OrderStatus = "Hold";

            if (Request.QueryString["SaleID"] == null)
            {
                int OrderNo = GenerateOrderNo();
                //Insert Into sale table
                db.sp_SaleAdd(OrderNo, txtHoldRef.Text, DateTime.Now, Convert.ToInt32(ddlCustomer.SelectedValue), Convert.ToInt32(Session["ShopID"]), TotalItem, SubTotal,
                    TotalTax, Convert.ToDecimal(txtDiscount.Text), NetAmount, Convert.ToDecimal(txtPayment.Text), Change, Status, OrderStatus, txtNotes.Text, UserID, ref SaleID);

                //Check POS type Hold or not
                if (btnID.ID == "btnSave")
                {
                    //Insert payment in tblsalepayment
                    db.sp_SalePaymentAdd(SaleID, DateTime.Now, ddlPaidBy.SelectedValue, Convert.ToDecimal(txtPayment.Text));
                    dHelper.LogAction("User Add Sale Order No. " + OrderNo);
                }
                else                
                    dHelper.LogAction("User Add Hold Sale Order No. " + OrderNo);                
            }
            else if (Request.QueryString["SaleID"] != null)
            {
                SaleID = Convert.ToInt32(dHelper.Decrypt(Request.QueryString["SaleID"].ToString()));

                //Insert Into sale table
                db.sp_SaleUpdate(SaleID,txtHoldRef.Text, Convert.ToInt32(ddlCustomer.SelectedValue),TotalItem, SubTotal,
                    TotalTax, Convert.ToDecimal(txtDiscount.Text), NetAmount, Convert.ToDecimal(txtPayment.Text), Change, Status, OrderStatus, txtNotes.Text, UserID);
                //delete all entry in saledetail table
                var saleDetail = db.tblSaleDetails.Where(s => s.SaleID == SaleID);
                db.tblSaleDetails.DeleteAllOnSubmit(saleDetail);
                //delete all entry in saletax table
                var saleTax = db.tblSaleTaxes.Where(s => s.SaleID == SaleID);
                db.tblSaleTaxes.DeleteAllOnSubmit(saleTax);

                if (btnID.ID == "btnSave")
                {
                    //Insert payment in tblsalepayment
                    db.sp_SalePaymentAdd(SaleID, DateTime.Now, ddlPaidBy.SelectedValue, Convert.ToDecimal(txtPayment.Text));
                    dHelper.LogAction("User Update Sale Order No. " + HiddenOrderNo.Value);
                }
                else
                    dHelper.LogAction("User Update Hold Sale Order No. " + HiddenOrderNo.Value);     
            }

            if (Session["Sale"] != null)
                cart = HttpContext.Current.Session["Sale"] as Helper.ShoppingCart;
            if (cart != null)
            {
                foreach (var t in cart.Items)
                {
                    var product = db.tblItems.FirstOrDefault(s => s.ID == t.ProductID);
                    if (product != null)
                    {
                        Decimal SellPrice = Convert.ToDecimal(dHelper.GetItemSellingPrice(product.ID));
                        Decimal Discount = ((product.SellingPrice.Value * product.DiscountRate.Value) / 100);
                        Decimal ItemNetAmount = (SellPrice * t.Quantity);
                        //Insert sale Item in tblsaledetail
                        db.sp_SaleDetailAdd(SaleID, product.ID, t.Quantity, product.SellingPrice, SellPrice, product.DiscountRate, Discount, ItemNetAmount);
                    }
                }
            }

            var tax = db.sp_GetTax();
            foreach (var t in tax)
            {
                Decimal TaxAmount = (SubTotal * t.TaxRate.Value) / 100;
                //Insert tax in tblsaletax
                if (TaxAmount > 0)
                    db.sp_SaleTaxAdd(SaleID, t.ID, t.TaxRate, TaxAmount);
            }
            
            db.SubmitChanges();
            transaction.Commit();
            SetDefaultValue();
            Session.Remove("Sale");
            if (btnID.ID == "btnSave")
                Response.Redirect("/Sales/SaleReceipt.aspx?SaleID=" + dHelper.Encrypt(SaleID.ToString()));
            else
            {
                Session["Hold"] = "Hold";
                Response.Redirect(Request.Path);                
            }
        }

        public int GenerateOrderNo()
        {
            var orderNo = db.tblSales.Max(s => s.OrderNo);
            if (orderNo != null)
                return orderNo.Value + 1;
            else
                return 1;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Session.Remove("Sale");            
            SetDefaultValue();
        }

        public void SetDefaultValue()
        {
            HiddenID.Value = "";
            ltrTitle.Text = "Payment";
            txtPayment.Text = "";
            txtNotes.Text = "";
            txtDiscount.Text = "";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('.select2').select2();", true);
            upModal.Update();
        }
    }
}