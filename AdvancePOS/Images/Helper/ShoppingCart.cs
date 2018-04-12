using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancePOS.Helper
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items
        {
            get;
            set;
        }

        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }

        public void AddItem(ShoppingCartItem newCartItem)
        {
            try
            {
                var produtct = Items.Where(s => s.ProductID == newCartItem.ProductID).FirstOrDefault();
                if (produtct != null)
                {
                    foreach (ShoppingCartItem item in Items)
                    {
                        if (item.ProductID == newCartItem.ProductID)
                        {
                            item.Quantity = item.Quantity + newCartItem.Quantity;
                            return;
                        }
                    }
                }
                else
                {
                    ShoppingCartItem item = new ShoppingCartItem();
                    item.Quantity = newCartItem.Quantity;
                    Items.Add(newCartItem);
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateQuantity(int ProductID, int Qty)
        {
            try
            {
                if (Qty <= 0)
                {
                    RemoveItem(ProductID);
                }
                foreach (ShoppingCartItem item in Items)
                {
                    if (item.ProductID == ProductID)
                    {
                        item.Quantity = Qty;
                        return;
                    }
                }
            }
            catch
            {
            }
        }       

        public void RemoveItem(int ProductID)
        {
            foreach (ShoppingCartItem item in Items)
            {
                if (item.ProductID == ProductID)
                {
                    Items.Remove(item);
                    break;
                }
            }
        }
    }
}