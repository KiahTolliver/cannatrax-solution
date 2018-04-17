using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class UserPermissionRepository:IUserPermissionRepository
    {
        private readonly IEntityRepository<tblUserPermission> _repo;
        
        public UserPermissionRepository(IEntityRepository<tblUserPermission> repo)
        {
            _repo = repo;
        }

        public tblUserPermission Add(tblUserPermission dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblUserPermission dbo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblUserPermission> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblUserPermission GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblUserPermission Update(tblUserPermission dbo)
        {
            throw new NotImplementedException();
        }
    }
}
