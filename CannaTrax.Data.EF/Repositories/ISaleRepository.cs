using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface ISaleRepository
    {
        tblSale Add(tblSale dbo);
        tblSale Update(tblSale dbo);
        void Delete(tblSale dbo);
        IEnumerable<tblSale> GetAll();
        tblSale GetById(int id);
    }
}
