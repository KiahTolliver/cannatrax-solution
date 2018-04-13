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
    }
}
