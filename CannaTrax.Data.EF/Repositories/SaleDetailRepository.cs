using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class SaleDetailRepository:ISaleDetailRepository
    {
        private readonly IEntityRepository<tblSaleDetail> _repo;

        public SaleDetailRepository(IEntityRepository<tblSaleDetail> repo)
        {
            _repo = repo;
        }

        public tblSaleDetail Add(tblSaleDetail dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblSaleDetail dbo)
        {
                _repo.Update(dbo);
        }

        public IEnumerable<tblSaleDetail> GetAll()
        {
            var ret = _repo.Queryable();
            return ret;
        }

        public tblSaleDetail GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id).FirstOrDefault();
            return ret;
        }

        public tblSaleDetail Update(tblSaleDetail dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
