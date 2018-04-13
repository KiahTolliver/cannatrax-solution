using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class SalePaymentRepository:ISalePaymentRepository
    {
        private readonly IEntityRepository<tblSalePayment> _repo;

        public SalePaymentRepository(IEntityRepository<tblSalePayment> repo)
        {
            _repo = repo;
        }
    }
}
