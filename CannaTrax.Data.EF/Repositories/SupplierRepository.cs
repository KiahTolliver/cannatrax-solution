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
    }
}
