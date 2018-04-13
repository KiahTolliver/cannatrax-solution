using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface IPurchaseDetailRepository
    {
        tblPurchaseDetail Add(tblPurchaseDetail dbo);
        tblPurchaseDetail Update(tblPurchaseDetail dbo);
        void Delete(tblPurchaseDetail dbo);
        List<tblPurchaseDetail> GetAll();
        tblPurchaseDetail GetById(int id);
    }
}
