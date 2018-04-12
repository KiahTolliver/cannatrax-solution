using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Report
{
    public partial class SaleReport : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                PopulateSale();                
            }
        }

        private void PopulateSale()
        {
            DateTime? fromDate = new Nullable<DateTime>();
            DateTime? toDate = new Nullable<DateTime>();

            if (!String.IsNullOrEmpty(txtFromDate.Text))
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text);
                toDate = DateTime.Now.AddDays(1);
            }

            if (!String.IsNullOrEmpty(txtToDate.Text))
                toDate = Convert.ToDateTime(txtToDate.Text).AddDays(1);

            var sales = db.sp_GetSaleHistory(fromDate, toDate).ToList();

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateSale();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
            PopulateSale();
        }
    }
}