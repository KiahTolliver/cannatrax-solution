using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface ICustomerRepository
    {
        tblCustomer Add(tblCustomer dbo);
        tblCustomer Update(tblCustomer dbo);
        void Delete(tblCustomer dbo);
        List<tblCustomer> GetAll();
        tblCustomer GetById(int id);
    }
}
