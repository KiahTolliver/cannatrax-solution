using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface IUserPermissionRepository
    {
        tblUserPermission Add(tblUserPermission dbo);
        tblUserPermission Update(tblUserPermission dbo);
        void Delete(tblUserPermission dbo);
        IEnumerable<tblUserPermission> GetAll();
        tblUserPermission GetById(int id);
    }
}
