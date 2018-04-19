using CannaTraxx.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.Processors
{
    public interface IUserProcessor
    {
        UserModel Add(UserModel user);
        IEnumerable<UserModel> GetAllEmployees();
        UserModel GetEmployeeById(int id);
        UserModel UpdateEmployee(UserModel user);
        void Delete(UserModel user);
    }
}
