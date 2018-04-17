using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface IPurchaseRepository
    {
        tblPurchase Add(tblPurchase dbo);
        tblPurchase Update(tblPurchase dbo);
        void Delete(tblPurchase dbo);
        IEnumerable<tblPurchase> GetAll();
        tblPurchase GetById(int id);
    }
}
