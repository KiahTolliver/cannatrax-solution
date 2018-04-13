using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface ISaleTaxRepository
    {
        tblSaleTax Add(tblSaleTax dbo);
        tblSaleTax Update(tblSaleTax dbo);
        void Delete(tblSaleTax dbo);
        List<tblSaleTax> GetAll();
        tblSaleTax GetById(int id);
    }
}
