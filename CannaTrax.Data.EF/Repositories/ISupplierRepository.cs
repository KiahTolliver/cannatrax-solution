using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface ISupplierRepository
    {
        tblSupplier Add(tblSupplier dbo);
        tblSupplier Update(tblSupplier dbo);
        void Delete(tblSupplier dbo);
        List<tblSupplier> GetAll();
        tblSupplier GetById(int id);
    }
}
