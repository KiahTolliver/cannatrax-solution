using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IEntityRepository<tblUser> _repo;

        public UserRepository(IEntityRepository<tblUser> repo)
        {
            _repo = repo;
        }
    }
}
