using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AdvancePOS.Models;
using AdvancePOS.Helper;

namespace AdvancePOS.Helper
{
    /// <summary>
    /// Summary description for AdvancePOS
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AdvancePOS : System.Web.Services.WebService
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        GeneralHelper dHelper = new GeneralHelper();
        Helper.ShoppingCart cart = null;


        //Purchase Add To Cart
        [WebMethod(EnableSession = true)]
        public string AddToCartPurchase(int ItemID)
        {
            ShoppingCartItem items = new ShoppingCartItem();
            items.ProductID = ItemID;
            items.Quantity = 1;

            ////Check Item Quantity
            if (dHelper.GetItemQuantity(ItemID) < 1)
                return "";

            if (HttpContext.Current.Session["Purchase"] == null)
            {
                cart = new Helper.ShoppingCart();
                HttpContext.Current.Session["Purchase"] = cart;
            }
            else
                cart = HttpContext.Current.Session["Purchase"] as Helper.ShoppingCart;
            cart.AddItem(items);

            HttpContext.Current.Session["Purchase"] = cart;

            return GetPurchaseItem()[0];
        }

        //Delete Purchase Item
        [WebMethod(EnableSession = true)]
        public String DeletePurchaseItem(int ItemID)
        {            
            if (Session["Purchase"] != null)
                cart = HttpContext.Current.Session["Purchase"] as Helper.ShoppingCart;

            cart.RemoveItem(ItemID);
            if (cart.Items.Count() <= 0)
            {
                cart = null;
                Session["Purchase"] = null;
                Session.Remove("Purchase");                
            }
            else
            {
                HttpContext.Current.Session["Purchase"] = cart;                
            }            
            return GetPurchaseItem()[0];
        }

        //Update Purchase Item
        [WebMethod(EnableSession = true)]
        public String UpdatePurchaseItem(int ItemID, int Qty)
        {            
            if (Session["Purchase"] != null)
                cart = HttpContext.Current.Session["Purchase"] as Helper.ShoppingCart;

            cart.UpdateQuantity(ItemID, Qty);

            HttpContext.Current.Session["Purchase"] = cart;            
            return GetPurchaseItem()[0];
        }

        //Get All Purchase Item
        [WebMethod(EnableSession = true)]
        public string[] GetPurchaseItem()
        {
            String[] str = new String[] { "", "", "", "" };
            Decimal TotalAmount = 0, TotalItem = 0;
            if (Session["Purchase"] != null)
                cart = HttpContext.Current.Session["Purchase"] as Helper.ShoppingCart;
            if (cart != null)
            {
                str[0] += "<table class=\"table table-striped\"><thead><tr><th width=\"5%\"></th><th width=\"30%\" class=\"name\">Name</th><th width=\"20%\">Price</th><th width=\"15%\">Qty</th><th width=\"30%\">Total</th></tr></thead><tbody>";
                foreach (var t in cart.Items)
                {
                    var product = db.tblItems.FirstOrDefault(s => s.ID == t.ProductID);
                    if (product != null)
                    {
                        String PurchaseRate = product.PurchasePrice.ToString();
                        String Total = (Convert.ToDecimal(PurchaseRate) * t.Quantity).ToString();
                        str[0] += String.Format("<tr><td><a onclick=\"DeletePurchaseItem('{0}')\" class=\"delete\"><i class=\"fa fa-times-circle-o\"></i></a></td>", product.ID);
                        str[0] += String.Format("<td class=\"name\">{0}</td><td>{2}</td><td><input class=\"form-control qty\" onchange=\"UpdatePurchaseItem('{4}',this.value)\" value=\"{1}\"></td><td>{3}</td></tr>", product.Name, t.Quantity, PurchaseRate, Total, product.ID);
                        TotalAmount += Convert.ToDecimal(Total);
                        TotalItem += t.Quantity;
                    }
                }
                str[0] += String.Format("</tbody><tfoot><tr><th colspan=\"2\"></th><th colspan=\"2\"><b>Total</b></th><th><b>{0} {1}</b></th></tr>", TotalAmount, dHelper.GetCurrency());
                str[0] += String.Format("<tr><th colspan=\"2\"><b></b></th><th colspan=\"2\"><b>Total Items</b></th><th><b>{0}</b></th></tr></tfoot>", TotalItem);
                str[0] += "</table>";
            }
            str[1] = TotalAmount.ToString();
            str[2] = TotalItem.ToString();
            str[3] = dHelper.GetCurrency();
            return str;
        }

        //Sale Add To Cart
        [WebMethod(EnableSession = true)]
        public string[] AddToCartSale(int ItemID)
        {
            String[] str = new String[] { "", "" };
            ShoppingCartItem items = new ShoppingCartItem();
            items.ProductID = ItemID;
            items.Quantity = 1;

            if (HttpContext.Current.Session["Sale"] == null)
            {
                cart = new Helper.ShoppingCart();
                HttpContext.Current.Session["Sale"] = cart;
            }
            else
            {
                cart = HttpContext.Current.Session["Sale"] as Helper.ShoppingCart;
                var qty = cart.Items.FirstOrDefault(s => s.ProductID == ItemID);
                if (qty != null)
                {
                    if (qty.Quantity >=Convert.ToInt32(dHelper.GetItemStock(ItemID)))
                    {
                        str[1] = "low";
                        return str;
                    }
                }
            }
            cart.AddItem(items);

            HttpContext.Current.Session["Sale"] = cart;

            str[0] = GetSaleItem().ProductList;
            return str;
        }

        //Delete Sale Item
        [WebMethod(EnableSession = true)]
        public String DeleteSaleItem(int ItemID)
        {
            if (Session["Sale"] != null)
                cart = HttpContext.Current.Session["Sale"] as Helper.ShoppingCart;

            cart.RemoveItem(ItemID);
            if (cart.Items.Count() <= 0)
            {
                cart = null;
                Session["Sale"] = null;
                Session.Remove("Sale");
            }
            else
            {
                HttpContext.Current.Session["Sale"] = cart;
            }
            return GetSaleItem().ProductList;
        }

        //Update Sale Item
        [WebMethod(EnableSession = true)]
        public String[] UpdateSaleItem(int ItemID, int Qty)
        {
            String[] str = new String[] { "", "" };
            if (Session["Sale"] != null)
            {
                cart = HttpContext.Current.Session["Sale"] as Helper.ShoppingCart;
                if (Qty > dHelper.GetItemQuantity(ItemID))
                {
                    str[1] = "low";
                    var qty=cart.Items.FirstOrDefault(s => s.ProductID == ItemID);
                    if (qty != null)
                        str[0] = qty.Quantity.ToString();
                    return str;
                }
                cart.UpdateQuantity(ItemID, Qty);
            }

            HttpContext.Current.Session["Sale"] = cart;
            str[0] = GetSaleItem().ProductList;
            
            return str;
        }

        //Get All Sale Item
        [WebMethod(EnableSession = true)]
        public SaleDetail GetSaleItem()
        {
            SaleDetail sDetail = new SaleDetail();

            String ProductList = "";
            Decimal SubTotal = 0, TotalItem = 0, NetAmount = 0, TotalTax = 0;
            string Currency = dHelper.GetCurrency();
            if (Session["Sale"] != null)
                cart = HttpContext.Current.Session["Sale"] as Helper.ShoppingCart;
            if (cart != null)
            {
                ProductList += "<table class=\"table table-striped\"><thead><tr><th width=\"5%\"></th><th width=\"30%\" class=\"name\" >Name</th><th width=\"20%\">Price</th><th width=\"15%\">Qty</th><th width=\"30%\">Total</th></tr></thead><tbody>";
                foreach (var t in cart.Items)
                {
                    var product = db.tblItems.FirstOrDefault(s => s.ID == t.ProductID);
                    if (product != null)
                    {
                        String SellRate = dHelper.GetItemSellingPrice(product.ID);
                        String Total = (Convert.ToDecimal(SellRate) * t.Quantity).ToString();
                        ProductList += String.Format("<tr><td><a onclick=\"DeleteSaleItem('{0}')\" class=\"delete\"><i class=\"fa fa-times-circle-o\"></i></a></td>", product.ID);
                        ProductList += String.Format("<td class=\"name\">{0}</td><td>{2}</td><td><input class=\"form-control qty\" onchange=\"UpdateSaleItem('{4}',this.value)\" value=\"{1}\"></td><td>{3}</td></tr>", product.Name, t.Quantity, SellRate, Total, product.ID);
                        SubTotal += Convert.ToDecimal(Total);
                        TotalItem += t.Quantity;
                    }
                }
                ProductList += String.Format("</tbody><tfoot><tr><th></th><th colspan=\"3\"><b>Total</b></th><th><b>{0} {1}</b></th></tr>", SubTotal, Currency);

                NetAmount = SubTotal;
                var tax = db.sp_GetTax().Where(s => s.IsActive == true);
                foreach (var t in tax)
                {
                    Decimal TaxAmount = (SubTotal * t.TaxRate.Value) / 100;
                    ProductList += String.Format("<tr><th><b></b></th><th colspan=\"3\"><b>{0} ({1}%)</b></th><th><b>{2} {3}</b></th></tr>", t.Name, t.TaxRate, TaxAmount.ToString("0.00"), Currency);
                    NetAmount += TaxAmount;
                    TotalTax += TaxAmount;
                }
                ProductList += String.Format("<tr><th><b></b></th><th colspan=\"3\"><b>Net Amount</b></th><th><b><span id=\"total\">{0}</span> {1}</b></th></tr>", NetAmount.ToString("0.00"), Currency);
                ProductList += String.Format("<tr><th><b></b></th><th colspan=\"3\"><b>Total Items</b></th><th><b>{0}</b></th></tr></tfoot>", TotalItem);
                ProductList += "</table>";
            }

            sDetail.ProductList = ProductList;
            sDetail.NetAmount = NetAmount.ToString("0.00");
            sDetail.TotalItem = TotalItem.ToString();
            sDetail.Currency = dHelper.GetCurrency();
            sDetail.SubTotal = SubTotal.ToString("0.00");
            sDetail.TotalTax = TotalTax.ToString("0.00");
            //return str;

            return sDetail;
        }

        public class SaleDetail
        {
            public string ProductList;
            public string SubTotal;
            public string NetAmount;
            public string TotalItem;
            public string Currency;
            public string TotalTax;
        }
        
         //Get All Sale Item
        [WebMethod(EnableSession = true)]
        public String GetOpenedBills(String RefNo)
        {
            String str = "";
            str += "<center>";
            var sales = db.sp_GetSaleHistory(null, null).Where(s => s.OrderStatus == "Hold").ToList();
            if (Session["UserID"] != null)
            {
                int UserID = Convert.ToInt32(Session["UserID"].ToString());
                var userInfo = db.tblUsers.FirstOrDefault(s => s.ID == UserID);
                if (userInfo != null)
                    if (userInfo.tblRole.IsSuperAdmin == false)
                        sales = sales.Where(s => s.ShopID == userInfo.ShopID).ToList();
            }
            if (RefNo != "")
            {
                sales = sales.Where(s => s.RefNumber != null).ToList();
                sales = sales.Where(s => s.RefNumber.Contains(RefNo)).ToList();
            }
            foreach (var s in sales)
            {
                str += String.Format("<a href=\"/Sales/ManageSale.aspx?SaleID={0}\"><div class=\"col-md-5 bill\"><b>Ref. No</b> : {1}<br>", dHelper.Encrypt(s.ID.ToString()), s.RefNumber);
                str += String.Format("<b>Customer </b>: {0}<br><b>Date </b>: {1}<br><b>Item Qty.</b> : {2}<br><b>Total </b>: {3}", s.CustomerName, s.OrderDate, s.TotalItem, s.NetAmount);
                str += "</div></a>";                
            }
            str += "</center>";
            return str;
        }

        [WebMethod]
        public string MonthlySaleStatistic()
        {
            string str = "";
            string saleData = "";
            var order = (from m in db.tblSales
                         where m.IsDeleted == false
                         where m.OrderDate.Value.Year == DateTime.Now.Year
                         select m).ToList();
            for (int i = 1; i <= 12; i++)
            {
                var janOrder = order.Where(m => m.OrderDate.Value.Month == i).Sum(s => s.NetAmount);
                if (janOrder > 0)
                    saleData += janOrder.ToString() + ",";
                else
                    saleData += " 0,";
            }
            str+="<script type=\"text/javascript\">";
            str += "var salesChartData = {labels: [\"January\", \"February\", \"March\", \"April\", \"May\", \"June\", \"July\", \"August\", \"September\", \"Octomber\", \"November\", \"December\"],";
            str += "datasets: [{label: \"Sales\",fillColor: \"rgba(60,141,188,0.9)\",strokeColor: \"rgba(60,141,188,0.8)\",pointColor: \"#3b8bba\",";
            str += "pointStrokeColor: \"rgba(60,141,188,1)\",pointHighlightFill: \"#fff\",pointHighlightStroke: \"rgba(60,141,188,1)\",";
            str += "data: [" + saleData + "]}]};";
            str += "salesChart.Line(salesChartData, salesChartOptions);";
            str += "</script>";
            return str;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
    }
}
