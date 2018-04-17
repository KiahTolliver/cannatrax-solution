using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class PurchaseRepository:IPurchaseRepository
    {
        private readonly IEntityRepository<tblPurchase> _repo;

        public PurchaseRepository(IEntityRepository<tblPurchase> repo)
        {
            _repo = repo;
        }

        public tblPurchase Add(tblPurchase dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblPurchase dbo)
        {
            _repo.Update(dbo);
        }

        public IEnumerable<tblPurchase> GetAll()
        {
            var ret = _repo.Queryable().Where(x => x.IsDeleted == false);
            return ret;
        }

        public tblPurchase GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefault();
            return ret;
        }

        public tblPurchase Update(tblPurchase dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
