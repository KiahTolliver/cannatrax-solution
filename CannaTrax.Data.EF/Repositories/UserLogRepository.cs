using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class UserLogRepository:IUserLogRepository
    {
        private readonly IEntityRepository<tblUserLog> _repo;

        public UserLogRepository(IEntityRepository<tblUserLog> repo)
        {
            _repo = repo;
        }
    }
}
