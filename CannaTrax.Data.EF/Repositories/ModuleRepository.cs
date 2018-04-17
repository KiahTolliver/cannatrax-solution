using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class ModuleRepository: IModuleRepository
    {
        private readonly IEntityRepository<tblModule> _repo;
        public ModuleRepository(IEntityRepository<tblModule> repo)
        {
            _repo = repo;
        }
    }
}
