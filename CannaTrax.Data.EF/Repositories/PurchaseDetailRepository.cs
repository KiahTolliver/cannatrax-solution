using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class PurchaseDetailRepository:IPurchaseDetailRepository
    {
        private readonly IEntityRepository<tblPurchaseDetail> _repo;
        public PurchaseDetailRepository(IEntityRepository<tblPurchaseDetail> repo)
        {
            _repo = repo;
        }

        public tblPurchaseDetail Add(tblPurchaseDetail dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblPurchaseDetail dbo)
        {
            _repo.Update(dbo);
        }

        public List<tblPurchaseDetail> GetAll()
        {
            var ret = _repo.Queryable().ToList();
            return ret;
        }

        public tblPurchaseDetail GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id).FirstOrDefault();
            return ret;
        }

        public tblPurchaseDetail Update(tblPurchaseDetail dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
