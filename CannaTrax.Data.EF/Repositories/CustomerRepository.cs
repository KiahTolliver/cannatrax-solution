using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
   public class CustomerRepository:ICustomerRepository
    {
        private readonly IEntityRepository<tblCustomer> _repo;
        public CustomerRepository(IEntityRepository<tblCustomer> repo)
        {
            _repo = repo;
        }

        public tblCustomer Add(tblCustomer dbo)
        {
            _repo.Insert(dbo);
            return dbo;
        }

        public void Delete(tblCustomer dbo)
        {
            _repo.Update(dbo);
        }

        public List<tblCustomer> GetAll()
        {
            var ret = _repo.Queryable().Where(x => x.IsDeleted == false).ToList();
            return ret;
        }

        public tblCustomer GetById(int id)
        {
            var ret = _repo.Queryable().Where(x => x.ID == id && x.IsDeleted == false).FirstOrDefault();
            return ret;
        }

        public tblCustomer Update(tblCustomer dbo)
        {
            _repo.Update(dbo);
            return dbo;
        }
    }
}
