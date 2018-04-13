using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class GeneralSettingsRepository:IGeneralSettingsRepository
    {
        private readonly IEntityRepository<tblGeneralSetting> _repo;
        public GeneralSettingsRepository(IEntityRepository<tblGeneralSetting> repo)
        {
            _repo = repo;
        }
    }
}
