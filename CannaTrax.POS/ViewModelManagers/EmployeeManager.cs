using CannaTrax.POS.ViewModels;
using CannaTraxx.Common.Models;
using CannaTraxx.Common.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CannaTrax.POS.ViewModelManagers
{
    public class EmployeeManager:IEmployeeManager
    {
        private IUserProcessor _userProcessor;

        public EmployeeManager(UserProcessor userProcessor)
        {
            _userProcessor = userProcessor;
        }
        public EmployeeManager():this(new UserProcessor())
        {

        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            var employeeList = _userProcessor.GetAllEmployees();
            var ret = new List<Employee>();
            foreach (var employee in employeeList)
            {
                ret.Add(ToViewModel(employee));
            }

            return ret;
        }

        public Employee GetEmployeeById(int id)
        {
            var ret = _userProcessor.GetEmployeeById(id);
            return ToViewModel(ret);
        }
        
        public Employee UpdateEmployee(Employee employee)
        {
            var ret = _userProcessor.UpdateEmployee(ToModel(employee));
            return ToViewModel(ret);
        }

        public Employee AddEmployee(Employee employee)
        {
            var ret = _userProcessor.Add(ToModel(employee));
            return ToViewModel(ret);
        }

        private Employee ToViewModel(UserModel model)
        {
            var ret = new Employee()
            {
                Id = model.ID,
                RoleID = model.RoleID,
                ShopID = model.ShopID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                Department = model.Department,
                Designation = model.Designation,
                Supervisor = model.Supervisor,
                DateOfBirth = model.DateOfBirth, 
                Address = model.Address, 
                PhotoPath = model.PhotoPath, 
                UserName = model.UserName, 
                Password = model.Password, 
                IsActive = model.IsActive, 
            };
            return ret;
        }

        private UserModel ToModel(Employee viewModel)
        {
            var ret = new UserModel()
            {
                RoleID = viewModel.RoleID, 
                ShopID = viewModel.ShopID,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName, 
                PhoneNo = viewModel.PhoneNo, 
                Email = viewModel.Email, 
                Department = viewModel.Department, 
                Designation = viewModel.Designation,
                Supervisor = viewModel.Supervisor, 
                DateOfBirth = viewModel.DateOfBirth, 
                Address = viewModel.Address, 
                PhotoPath = viewModel.PhotoPath, 
                UserName = viewModel.UserName,
                Password = viewModel.Password, 
                IsActive = viewModel.IsActive
            };

            return ret;
        }
    
    

    }
}