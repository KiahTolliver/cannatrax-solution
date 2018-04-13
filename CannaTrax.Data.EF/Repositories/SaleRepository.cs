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
    }
}
