using CannaTraxx.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.Processors
{
    public interface IItemProcessor
    {
        ItemModel AddProduct(ItemModel model);
        IEnumerable<ItemModel> GetAllProducts();
        ItemModel UpdateProduct(ItemModel model);
        ItemModel GetById(int id);
        void Delete(int id);

    }
}
