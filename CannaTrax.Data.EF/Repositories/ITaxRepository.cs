using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
  public interface ITaxRepository
    {
        tblTax Add(tblTax dbo);
        tblTax Update(tblTax dbo);
        void Delete(tblTax dbo);
        List<tblTax> GetAll();
        tblTax GetById(int id);
    }
}
