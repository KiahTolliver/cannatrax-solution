using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface ISaleDetailRepository
    {
        tblSaleDetail Add(tblSaleDetail dbo);
        tblSaleDetail Update(tblSaleDetail dbo);
        void Delete(tblSaleDetail dbo);
        IEnumerable<tblSaleDetail> GetAll();
        tblSaleDetail GetById(int id);
    }
}
