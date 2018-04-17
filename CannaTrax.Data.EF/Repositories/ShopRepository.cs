using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class ShopRepository:IShopRepository
    {
        private readonly IEntityRepository<tblShop> _repo;

        public ShopRepository(IEntityRepository<tblShop> repo)
        {
            _repo = repo;
        }

        public tblShop Add(tblShop dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblShop dbo)
        {
            throw new NotImplementedException();
        }

        public List<tblShop> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblShop GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblShop Update(tblShop dbo)
        {
            throw new NotImplementedException();
        }
    }
}
