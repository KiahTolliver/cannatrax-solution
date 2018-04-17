using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class TaxRepository:ITaxRepository
    {
        private readonly IEntityRepository<tblTax> _repo;

        public TaxRepository(IEntityRepository<tblTax> repo)
        {
            _repo = repo;
        }

        public tblTax Add(tblTax dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblTax dbo)
        {
            throw new NotImplementedException();
        }

        public List<tblTax> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblTax GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblTax Update(tblTax dbo)
        {
            throw new NotImplementedException();
        }
    }
}
