using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface IGeneralSettingsRepository
    {
        tblGeneralSetting Add(tblGeneralSetting dbo);
        tblGeneralSetting Update(tblGeneralSetting dbo);
        void Delete(tblGeneralSetting dbo);
        List<tblGeneralSetting> GetAll();
        tblGeneralSetting GetById(int id);
    }
}
