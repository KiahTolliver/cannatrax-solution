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
    public partial class SaleReceipt : System.Web.UI.Page
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
                    var setting = db.tblGeneralSettings.FirstOrDefault();
                    if (setting != null)
                    {
                        ImageLogo.ImageUrl = setting.CompanyLogo;
                        ltrAddress.Text = setting.Address;
                        ltrPhone.Text = setting.PhoneNo;
                    }
                    var order = db.tblSales.FirstOrDefault(s => s.ID == SaleID);
                    if (order != null)
                    {
                        dHelper.LogAction("User View Sales Receipt Order No. " + order.OrderNo);
                        ltrOrderNo.Text = order.OrderNo.ToString();
                        ltrDate.Text = order.OrderDate.ToString();
                        ltrTotalItem.Text = order.TotalItem.ToString();
                        ltrSubTotal.Text = order.SubTotal.ToString() + " " + Currency;
                        ltrNetAmount.Text = order.NetAmount.ToString() + " " + Currency;
                        ltrPayment.Text = order.Payment.ToString() + " " + Currency;
                        ltrChange.Text = order.Change.ToString() + " " + Currency;

                        if (order.Payment < order.NetAmount)
                            ltrDue.Text = (order.NetAmount - order.Payment).ToString() + " " + Currency;
                        else
                            ltrDue.Text = "0.00 " + Currency;

                        string strImageURL = "/Helper/GenerateBarcodeImage.aspx?d=" + ltrOrderNo.Text + "&h=40&w=250&bc=&fc=&t=Code 128&il=false&if=PNG&align=c";
                        this.ImageBarcode.ImageUrl = strImageURL;

                        var orderDetail = from s in db.tblSaleDetails
                                          join t in db.tblItems on s.ItemID equals t.ID
                                          where s.SaleID == order.ID
                                          select new { t.Name, s.Quantity, s.NetAmount };

                        RpItem.DataSource = orderDetail;
                        RpItem.DataBind();

                        var taxDetail = from s in db.tblSaleTaxes
                                        join t in db.tblTaxes on s.TaxID equals t.ID
                                        where s.SaleID == order.ID
                                        select new { t.Name, t.TaxRate, s.TaxAmount };
                        rpTax.DataSource = taxDetail;
                        rpTax.DataBind();

                        var customer = db.tblCustomers.FirstOrDefault(s => s.ID == order.CustomerID);
                        if (customer != null)
                            ltrCustomer.Text = customer.Name;

                        var store = db.tblShops.FirstOrDefault(s => s.ID == order.ShopID);
                        if (store != null)
                        {
                            ltrStoreName.Text = store.Name;
                            ltrStorePhone.Text = store.PhoneNo;
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