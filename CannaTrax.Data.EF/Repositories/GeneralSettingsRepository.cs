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

        public tblGeneralSetting Add(tblGeneralSetting dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblGeneralSetting dbo)
        {
            _repo.Update(dbo);
        }

        public List<tblGeneralSetting> GetAll()
        {
            var ret = _repo.Queryable().ToList();
            return ret;
        }

        public tblGeneralSetting GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id).FirstOrDefault();
            return ret;
        }

        public tblGeneralSetting Update(tblGeneralSetting dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
