using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface ICategoryRepository
    {
        tblCategory Add(tblCategory dbo);
        tblCategory Update(tblCategory dbo);
        void Delete(tblCategory dbo);
        IEnumerable<tblCategory> GetAll();
        tblCategory GetById(int id);

    }
}
