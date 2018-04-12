using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancePOS.Models;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace AdvancePOS.Helper
{
    public class GeneralHelper
    {
        AdvancePOSDataContext db = new AdvancePOSDataContext();
        public static Boolean IsDeleteEnable = false; //if True delete enable
        public void LogAction(String Message)
        {
            try
            {
                if (HttpContext.Current.Session["UserID"] != null)
                {
                    System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                    int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                    Models.tblUserLog lg = new Models.tblUserLog();
                    lg.Message = Message;
                    lg.MoreInfo = browser.Browser + " " + browser.Version;
                    lg.LogTime = DateTime.Now;
                    lg.UserID = UserID;
                    lg.IPAddress = GetVisitorIPAddress();
                    db.tblUserLogs.InsertOnSubmit(lg);
                    db.SubmitChanges();
                }
            }
            catch { }
        }

        //get Login UserID
        public int GetLoginUserID()
        {
            int UserID = 0;
            if (HttpContext.Current.Session["UserID"] != null)
                UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());

            return UserID;
        }

        //get currency
        public string GetCurrency()
        {
            var setting = db.tblGeneralSettings.FirstOrDefault();
            if (setting != null)
                return setting.CurrencyCode;
            else
                return "INR";
        }

        //get currency
        public string GetItemSellingPrice(int ItemID)
        {
            var itemPrice = db.tblItems.FirstOrDefault(s => s.ID == ItemID);
            if (itemPrice != null)
            {                
                return (itemPrice.SellingPrice.Value - ((itemPrice.SellingPrice.Value * itemPrice.DiscountRate.Value) / 100)).ToString("0.00");
            }
            else
                return "0";
        }

        //get currency
        public string GetItemStock(int ItemID)
        {
            var itemPrice = db.sp_GetItemStock(ItemID).FirstOrDefault();
            if (itemPrice != null)
                return (itemPrice.OpeningBalance.Value + itemPrice.Inwards.Value - itemPrice.Outwards.Value).ToString("0");
            else
                return "0";
        }

        // get visitor ip address
        public string GetVisitorIPAddress()
        {
            string IPAdd = string.Empty;
            IPAdd = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(IPAdd))
                IPAdd = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return IPAdd;
        }

        // generate module url
        public string GetModuleSlug(String ModuleName, int ParentModuleID)
        {
            string result = string.Empty;
            ModuleName = ModuleName.Replace(" ", "");
            if (String.IsNullOrEmpty(result))
                result = ModuleName;
            if (ParentModuleID > 0)
                result = GetModuleByID(ParentModuleID).ModuleName.Replace(" ", "") + "_" + result;
            result = "li" + result;
            return RemoveIllegalCharacters(result);
        }

        public Models.tblModule GetModuleByID(int? CategoryID)
        {
            var module = (from c in db.tblModules
                          where c.ID == CategoryID
                          select c).FirstOrDefault();
            return module;
        }

        public Decimal GetItemQuantity(int ItemID)
        {
            var item = db.tblItems.FirstOrDefault(s => s.ID == ItemID);
            if (item != null)
                return item.Quantity.Value;
            else
                return 0;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "encryptionkey";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            string EncryptionKey = "encryptionkey";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private string RemoveExtraHyphen(string text)
        {
            if (text.Contains("__"))
            {
                text = text.Replace("__", "_");
                return RemoveExtraHyphen(text);
            }
            return text;
        }

        private string RemoveDiacritics(string text)
        {
            string Normalize = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= Normalize.Length - 1; i++)
            {
                char c = Normalize[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public string RemoveIllegalCharacters(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            text = text.Replace(":", string.Empty);
            text = text.Replace("/", string.Empty);
            text = text.Replace("?", string.Empty);
            text = text.Replace("#", string.Empty);
            text = text.Replace("[", string.Empty);
            text = text.Replace("]", string.Empty);
            text = text.Replace("@", string.Empty);
            text = text.Replace(",", string.Empty);
            text = text.Replace("\"", string.Empty);
            text = text.Replace("&", string.Empty);
            text = text.Replace(".", string.Empty);
            text = text.Replace("'", string.Empty);
            //text = text.Replace("_", string.Empty);
            text = text.Replace(" ", "-");
            text = RemoveDiacritics(text);
            text = RemoveExtraHyphen(text);

            return HttpUtility.UrlEncode(text.ToLower()).Replace("%", string.Empty);
        }

        public static string Strip(string text)
        {
            string s = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            s = s.Replace("&nbsp;", " ");
            s = Regex.Replace(s, @"\s+", " ");
            s = Regex.Replace(s, @"\r\n", "\n");
            s = Regex.Replace(s, @"\n+", "\n");
            return s;
        }

        public String GetTimeAgo(DateTime date)
        {
            String str = "";
            TimeSpan ts = DateTime.Now - date;

            if (ts.Days < 1)
            {
                if (ts.Hours < 1)
                {
                    if (ts.Minutes < 1)
                        str = "Just now";
                    else if (ts.Minutes > 0 && ts.Minutes < 61)
                        str = ts.Minutes + " mins ago";
                }
                else
                    str = ts.Hours + " hours ago";
            }
            else if ((ts.Days) < 7)
                str = ts.Days + " days ago";
            else
                str = date.ToString("MMM dd,yyyy");

            return str;
        }
    }
}