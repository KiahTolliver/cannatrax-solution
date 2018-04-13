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
    }
}
