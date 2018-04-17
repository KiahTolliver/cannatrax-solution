using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class SaleTaxRepository:ISaleTaxRepository
    {
        private readonly IEntityRepository<tblSaleTax> _repo;

        public SaleTaxRepository(IEntityRepository<tblSaleTax> repo)
        {
            _repo = repo;
        }

        public tblSaleTax Add(tblSaleTax dbo)
        {
            throw new NotImplementedException();
        }

        public void Delete(tblSaleTax dbo)
        {
            throw new NotImplementedException();
        }

        public List<tblSaleTax> GetAll()
        {
            throw new NotImplementedException();
        }

        public tblSaleTax GetById(int id)
        {
            throw new NotImplementedException();
        }

        public tblSaleTax Update(tblSaleTax dbo)
        {
            throw new NotImplementedException();
        }
    }
}
