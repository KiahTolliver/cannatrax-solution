using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CannaTrax.Data.EF;
using CannaTrax.Data.EF.Repositories;
using CannaTraxx.Common.Models;

namespace CannaTraxx.Common.Processors
{
    public class ItemProcessor : IItemProcessor
    {
        private IItemRepository _repo;
        public ItemProcessor(ItemRepository repo)
        {
            _repo = repo;
        }
        public ItemProcessor():this(new ItemRepository()) { }
        public ItemModel AddProduct(ItemModel model)
        {
            var ret = _repo.Add(ToDatabaseObject(model));
            return ToBusinessObject(ret);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemModel> GetAllProducts()
        {
            var ret = new List<ItemModel>();
            var itemList = _repo.GetAll();
            foreach(var item in itemList)
            {
                ret.Add(ToBusinessObject(item));
            }
            return ret;
        }

        public ItemModel GetById(int id)
        {
            var ret = _repo.GetById(id);
            return ToBusinessObject(ret);
        }

        public ItemModel UpdateProduct(ItemModel model)
        {
            var ret = _repo.Update(ToDatabaseObject(model));
            return ToBusinessObject(ret);
        }

        private tblItem ToDatabaseObject(ItemModel bo)
        {
            var ret = new tblItem
            {
                ID = bo.ID,
                CategoryID = bo.CategoryID,
                DiscountRate = bo.DiscountRate,
                ItemCode = bo.ItemCode,
                Name = bo.Name,
                PurchasePrice = bo.PurchasePrice,
                SellingPrice = bo.SellingPrice,
                Quantity = bo.Quantity,
                PhotoPath = bo.PhotoPath,
                IsDeleted = bo.IsDeleted
            };

            return ret;
        }

        private ItemModel ToBusinessObject(tblItem dbo)
        {
            var ret = new ItemModel
            {
                ID = dbo.ID,
                CategoryID = dbo.CategoryID,
                DiscountRate = dbo.DiscountRate,
                ItemCode = dbo.ItemCode,
                Name = dbo.Name,
                PurchasePrice = dbo.PurchasePrice,
                SellingPrice = dbo.SellingPrice,
                Quantity = dbo.Quantity,
                PhotoPath = dbo.PhotoPath,
                IsDeleted = dbo.IsDeleted
            };
            return ret;
        }
    }
}
