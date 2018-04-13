using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class SupplierRepository: ISupplierRepository
    {
        private readonly IEntityRepository<tblSupplier> _repo;

        public SupplierRepository(IEntityRepository<tblSupplier> repo)
        {
            _repo = repo;
        }

        public tblSupplier Add(tblSupplier dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblSupplier dbo)
        {
            throw new NotImplementedException();
        }

        public List<tblSupplier> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblSupplier GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblSupplier Update(tblSupplier dbo)
        {
            throw new NotImplementedException();
        }
    }
}
