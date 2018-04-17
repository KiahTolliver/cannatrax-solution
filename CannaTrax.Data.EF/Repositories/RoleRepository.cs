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

        public tblRole Add(tblRole dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblRole dbo)
        {
            _repo.Update(dbo);
        }

        public IEnumerable<tblRole> GetAll()
        {
            var ret = _repo.Queryable().Where(x => x.IsDeleted == false);
            return ret;
        }

        public tblRole GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefault();
            return ret;
        }

        public tblRole Update(tblRole dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
