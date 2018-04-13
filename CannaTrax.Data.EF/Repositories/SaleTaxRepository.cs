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
    }
}
