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

      
    }
}
