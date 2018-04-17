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

        public tblSalePayment Add(tblSalePayment dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblSalePayment dbo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblSalePayment> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblSalePayment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblSalePayment Update(tblSalePayment dbo)
        {
            throw new NotImplementedException();
        }
    }
}
