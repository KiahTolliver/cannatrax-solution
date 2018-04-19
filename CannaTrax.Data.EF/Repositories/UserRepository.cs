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
        public UserRepository():this(new EntityRepository<tblUser>())
        {

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
            var ret = _repo.Queryable().Where(x => x.IsDeleted == false).ToList();
            return ret;
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
