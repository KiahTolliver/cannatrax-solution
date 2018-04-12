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
    public partial class SaleInvoice : System.Web.UI.Page
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["SaleID"] != null)
                {
                    
                    int SaleID = Convert.ToInt32(dHelper.Decrypt(Request.QueryString["SaleID"].ToString()));
                    String Currency = dHelper.GetCurrency();
                    
                    //Get general setting
                    var setting = db.tblGeneralSettings.FirstOrDefault();
                    if (setting != null)
                    {
                        ltrCompanyName.Text = setting.CompanyName;
                        ltrCompanyName1.Text = setting.CompanyName;
                        ltrAddress.Text = setting.Address;
                        ltrPhone.Text = setting.PhoneNo;
                        ltrEmail.Text = setting.Email;
                    }

                    //get sale by saleid
                    var order = db.tblSales.FirstOrDefault(s => s.ID == SaleID);
                    if (order != null)
                    {
                        dHelper.LogAction("User View Sales Invoice Order No. " + order.OrderNo);
                        ltrOrderNo.Text = order.OrderNo.ToString();
                        ltrDate.Text = order.OrderDate.ToString();                        
                        ltrSubTotal.Text = order.SubTotal.ToString() + " " + Currency;
                        ltrNetAmount.Text = order.NetAmount.ToString() + " " + Currency;
                        ltrPayment.Text = order.Payment.ToString() + " " + Currency;
                        ltrChange.Text = order.Change.ToString() + " " + Currency;

                        if (order.Payment < order.NetAmount)
                            ltrDue.Text = (order.NetAmount - order.Payment).ToString() + " " + Currency;
                        else
                            ltrDue.Text = "0.00 " + Currency;

                        //get sale item details
                        var orderDetail = from s in db.tblSaleDetails
                                          join t in db.tblItems on s.ItemID equals t.ID
                                          where s.SaleID == order.ID
                                          select new { t.Name, t.ItemCode, s.SellPrice, s.Quantity, s.NetAmount };

                        RpItem.DataSource = orderDetail;
                        RpItem.DataBind();
                        
                        //get sale tax details
                        var taxDetail = from s in db.tblSaleTaxes
                                        join t in db.tblTaxes on s.TaxID equals t.ID
                                        where s.SaleID == order.ID
                                        select new { t.Name, t.TaxRate, s.TaxAmount };
                        rpTax.DataSource = taxDetail;
                        rpTax.DataBind();

                        //get sale payment details
                        var salePayment = db.tblSalePayments.Where(s => s.SaleID == order.ID).OrderByDescending(s => s.PaymentDate);
                        gvPayment.DataSource = salePayment;
                        gvPayment.DataBind();

                        var customer = db.tblCustomers.FirstOrDefault(s => s.ID == order.CustomerID);
                        if (customer != null)
                        {
                            ltrCustomerName.Text = customer.Name;
                            ltrCustomerAddress.Text = customer.Address;
                            ltrCustomerEmail.Text = customer.Email;
                            ltrCustomerPhone.Text = customer.PhoneNo;
                        }                        
                    }
                }
            }
        }

        //Get Amount With Currency
        protected string GetAmount(string NetAmount)
        {
            if (NetAmount != "")
                return NetAmount + " " + dHelper.GetCurrency();
            else
                return "";
        }
    }
}