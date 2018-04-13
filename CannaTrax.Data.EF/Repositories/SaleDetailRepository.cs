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
    }
}
