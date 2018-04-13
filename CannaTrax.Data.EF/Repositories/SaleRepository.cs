using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class SaleRepository: ISaleRepository
    {
        private readonly IEntityRepository<tblSale> _repo;

        public SaleRepository(IEntityRepository<tblSale> repo)
        {
            _repo = repo;
        }

        public tblSale Add(tblSale dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblSale dbo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblSale> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblSale GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblSale Update(tblSale dbo)
        {
            throw new NotImplementedException();
        }
    }
}
