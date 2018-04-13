using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface IShopRepository
    {
        tblShop Add(tblShop dbo);
        tblShop Update(tblShop dbo);
        void Delete(tblShop dbo);
        List<tblShop> GetAll();
        tblShop GetById(int id);
    }
}
