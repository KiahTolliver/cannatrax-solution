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

        public tblUser Add(tblUser dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblUser dbo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblUser Update(tblUser dbo)
        {
            throw new NotImplementedException();
        }
    }
}
