using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IEntityRepository<tblItem> _repo;

        public ItemRepository(IEntityRepository<tblItem> repo)
        {
            _repo = repo;
        }
        public tblItem Add(tblItem dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblItem dbo)
        {
            _repo.Update(dbo);
        }

        public IEnumerable<tblItem> GetAll()
        {
            var ret = _repo.Queryable().Where(x => x.IsDeleted == false);
            return ret;
        }

        public tblItem GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefault();
            return ret;      
        }

        public tblItem Update(tblItem dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
