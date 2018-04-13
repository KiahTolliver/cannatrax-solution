using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly IEntityRepository<tblRole> _repo;

        public RoleRepository(IEntityRepository<tblRole> repo)
        {
            _repo = repo;
        }
    }
}
