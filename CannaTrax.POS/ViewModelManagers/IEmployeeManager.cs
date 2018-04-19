using CannaTrax.POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.POS.ViewModelManagers
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
        Employee UpdateEmployee(Employee employee);
        Employee AddEmployee(Employee employee);
    }
}
