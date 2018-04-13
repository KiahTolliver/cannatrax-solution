using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
  public class CategoryRepository:ICategoryRepository
    {
        private readonly IEntityRepository<tblCategory> _repo;

        public CategoryRepository(IEntityRepository<tblCategory> repo)
        {
            _repo = repo;
        }

        public tblCategory Add(tblCategory dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblCategory dbo)
        {
            _repo.Update(dbo);

        }

        public IEnumerable<tblCategory> GetAll()
        {
            var ret = _repo.Queryable();
            return ret;
        }

        public tblCategory GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id).FirstOrDefault();
            return ret;
        }

        public tblCategory Update(tblCategory dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
