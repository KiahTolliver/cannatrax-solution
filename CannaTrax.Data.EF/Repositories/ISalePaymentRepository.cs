using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface ISalePaymentRepository
    {
        tblSalePayment Add(tblSalePayment dbo);
        tblSalePayment Update(tblSalePayment dbo);
        void Delete(tblSalePayment dbo);
        IEnumerable<tblSalePayment> GetAll();
        tblSalePayment GetById(int id);
    }
}
