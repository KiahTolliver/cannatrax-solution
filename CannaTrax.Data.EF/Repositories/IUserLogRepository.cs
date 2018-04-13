using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface IUserLogRepository
    {
        tblUserLog Add(tblUserLog dbo);
        tblUserLog Update(tblUserLog dbo);
        void Delete(tblUserLog dbo);
        IEnumerable<tblUserLog> GetAll();
        tblUserLog GetById(int id);
    }
}
