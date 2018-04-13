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
    }
}
