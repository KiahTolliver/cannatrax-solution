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
    }
}
