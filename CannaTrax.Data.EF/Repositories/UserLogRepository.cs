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

        public tblUserLog Add(tblUserLog dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblUserLog dbo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tblUserLog> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblUserLog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblUserLog Update(tblUserLog dbo)
        {
            throw new NotImplementedException();
        }
    }
}
