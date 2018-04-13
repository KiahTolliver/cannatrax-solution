using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface IItemRepository
    {
        tblItem Add(tblItem dbo);
        tblItem Update(tblItem dbo);
        void Delete(tblItem dbo);
        IEnumerable<tblItem> GetAll();
        tblItem GetById(int id);
    }
}
