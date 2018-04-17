using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface IRoleRepository
    {
        tblRole Add(tblRole dbo);
        tblRole Update(tblRole dbo);
        void Delete(tblRole dbo);
        IEnumerable<tblRole> GetAll();
        tblRole GetById(int id);
    }
}
