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
    public partial class SaleHistory : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateSale();
                POpulateCustomer();
                dHelper.LogAction("User View Sales History ");
            }
        }

        private void POpulateCustomer()
        {
            ddlCustomer.DataSource = db.sp_GetCustomer();
            ddlCustomer.DataValueField = "ID";
            ddlCustomer.DataTextField = "Name";
            ddlCustomer.DataBind();
        }

        private void PopulateSale()
        {
            var sales = db.sp_GetSaleHistory(null, null).ToList();
            if (Session["UserID"] != null)
            {
                int UserID = Convert.ToInt32(Session["UserID"].ToString());
                var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == UserID);
                if (userInfo != null)
                    if (userInfo.tblRole.IsSuperAdmin == false)
                        sales = sales.Where(s => s.ShopID == userInfo.ShopID).ToList();
            }
            gvSales.DataSource = sales;
            gvSales.DataBind();
            if (sales.Count() > 0)
            {
                gvSales.UseAccessibleHeader = true;
                gvSales.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gridview", "$('#MainContent_gvSales').DataTable();", true);
        }

        protected string GetStatus(string Status)
        {
            if (Status.ToLower() == "paid")
                return "<span class=\"label label-success\">Paid</span>";
            else if (Status.ToLower() == "unpaid")
                return "<span class=\"label label-danger\">UnPaid</span>";
            else if (Status.ToLower() == "partial payment")
                return "<span class=\"label label-warning\">Partial Payment</span>";
            else
                return "";
        }

        //Print Receipt
        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            var sales = db.tblSales.FirstOrDefault(s => s.ID == Convert.ToInt32(l.CommandArgument));
            if (sales != null)
            {
                if (GeneralHelper.IsDeleteEnable == true)
                    return;

                sales.IsDeleted = true;
                db.SubmitChanges();
                dHelper.LogAction("User Delete sales Order No. | " + sales.OrderNo);
                PopulateSale();
            }
        }

        protected void gvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String ID = (DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                HyperLink hReceipt = (HyperLink)e.Row.FindControl("HyperLinkReceipt");
                HyperLink hInvoice = (HyperLink)e.Row.FindControl("HyperInvoice");
                hReceipt.NavigateUrl = "/Sales/SaleReceipt.aspx?SaleID=" + dHelper.Encrypt(ID);
                hInvoice.NavigateUrl = "/Sales/SaleInvoice.aspx?SaleID=" + dHelper.Encrypt(ID);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            PopulateSale();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);            
        }

        protected void btnPaymentClose_Click(object sender, EventArgs e)
        {
            PopulateSale();
            txtPayment.Text = "0";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#payment').modal('hide');", true);
            upPayment.Update();
        }

         //Save and Update Sales
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var sales = db.tblSales.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (sales != null)
            {
                sales.CustomerID =Convert.ToInt32(ddlCustomer.SelectedValue);
                sales.Status = ddlStatus.SelectedValue.ToString();
                db.SubmitChanges();
                HiddenID.Value = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#edit').modal('hide');", true);
                dHelper.LogAction("User Change Order No. " + sales.OrderNo + " Status " + sales.Status);
                PopulateSale();
            }
        }

         //Edit Sales
        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenID.Value = l.CommandArgument;
            var sales = db.tblSales.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenID.Value));
            if (sales != null)
            {
                ddlStatus.SelectedValue = sales.Status;
                ddlCustomer.SelectedValue = sales.CustomerID.ToString();
                ltrNetAmount.Text = sales.NetAmount.Value.ToString("0.00") + " " + dHelper.GetCurrency();
                ltrPayment.Text = sales.Payment.Value.ToString("0.00") + " " + dHelper.GetCurrency();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#edit').modal({backdrop: 'static', keyboard: false});", true);
                PopulateSale();
                upModal.Update();
            }
        }

        //Edit Payment
        protected void LinkPayment_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            HiddenSaleID.Value = l.CommandArgument;
            var sales = db.tblSales.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenSaleID.Value));
            if (sales != null)
            {
                txtPayment.Text = "0";       
                ltrpNetAmount.Text = sales.NetAmount.Value.ToString("0.00") + " " + dHelper.GetCurrency();
                ltrpPayment.Text = sales.Payment.Value.ToString("0.00") + " " + dHelper.GetCurrency();

                var salePayment = db.tblSalePayments.Where(s => s.SaleID == sales.ID).OrderByDescending(s => s.PaymentDate);
                gvPayment.DataSource = salePayment;
                gvPayment.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mymodal", "$('#payment').modal({backdrop: 'static', keyboard: false});", true);
                upPayment.Update();
                PopulateSale();                
            }
        }

        //Save and Update Payment
        protected void btnSavePayment_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            var sales = db.tblSales.FirstOrDefault(s => s.ID == Convert.ToInt32(HiddenSaleID.Value));
            if (sales != null)
            {
                if (txtPayment.Text != "")
                {
                    if (sales.NetAmount < (sales.Payment + Convert.ToDecimal(txtPayment.Text)))
                    {
                        lblError.Text = "Amount greater than bill amount";
                        upPayment.Update();                    
                    }
                    else
                    {
                        db.sp_SalePaymentAdd(sales.ID, DateTime.Now, ddlPaidBy.SelectedValue, Convert.ToDecimal(txtPayment.Text));
                        sales.Payment = sales.Payment + Convert.ToDecimal(txtPayment.Text);

                        if (sales.NetAmount > sales.Payment)
                            sales.Status = "Partial Payment";
                        else if (txtPayment.Text == "0")
                            sales.Status = "UnPaid";
                        else
                            sales.Status = "Paid";

                        db.SubmitChanges();
                        dHelper.LogAction("User Add Payment Order No. " + sales.OrderNo);
                        HiddenSaleID.Value = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#payment').modal('hide');", true);
                    }
                }                
                PopulateSale();
            }
        }

        
    }
}