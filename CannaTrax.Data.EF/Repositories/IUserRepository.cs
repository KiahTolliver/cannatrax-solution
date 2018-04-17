using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public interface IUserRepository
    {
        tblUser Add(tblUser dbo);
        tblUser Update(tblUser dbo);
        void Delete(tblUser dbo);
        IEnumerable<tblUser> GetAll();
        tblUser GetById(int id);
    }
}
