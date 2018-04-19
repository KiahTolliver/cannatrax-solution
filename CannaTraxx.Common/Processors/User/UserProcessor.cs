using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CannaTrax.Data.EF;
using CannaTrax.Data.EF.Repositories;
using CannaTraxx.Common.Models;

namespace CannaTraxx.Common.Processors
{
    public class UserProcessor : IUserProcessor
    {
        private IUserRepository _repo;

        public UserProcessor(UserRepository repo)
        {
            _repo = repo;
        }
        public UserProcessor():this(new UserRepository())
        {

        }
        public UserModel Add(UserModel user)
        {
            var ret = _repo.Add(ToDatabaseObject(user));
            return ToBusinessObject(ret);
        }

        public void Delete(UserModel user)
        {
            _repo.Delete(ToDatabaseObject(user));
        }

        public IEnumerable<UserModel> GetAllEmployees()
        {
            var list = _repo.GetAll();
            var ret = new List<UserModel>();
            foreach(var item in list)
            {
                ret.Add(ToBusinessObject(item));
            }
            return ret;
        }

        public UserModel GetEmployeeById(int id)
        {
            var ret = _repo.GetById(id);
            return ToBusinessObject(ret);
        }

        public UserModel UpdateEmployee(UserModel user)
        {
            var ret = _repo.Update(ToDatabaseObject(user));
            return ToBusinessObject(ret);
        }

        public tblUser ToDatabaseObject(UserModel bo)
        {
            var ret = new tblUser()
            {
                ID = bo.ID,
                RoleID = bo.RoleID,
                ShopID = bo.ShopID,
                FirstName = bo.FirstName,
                LastName = bo.LastName,
                PhoneNo = bo.PhoneNo,
                Email = bo.Email,
                Department = bo.Department,
                Designation = bo.Designation,
                Supervisor = bo.Supervisor,
                DateOfBirth = bo.DateOfBirth,
                Address = bo.Address,
                PhotoPath = bo.PhotoPath,
                UserName = bo.UserName,
                Password = bo.Password,
                IsActive = bo.IsActive,
                IsDefault = bo.IsDefault,
                IsDeleted = bo.IsDeleted
            };

            return ret;
        }

        public UserModel ToBusinessObject(tblUser dbo)
        {
            var ret = new UserModel()
            {
                ID = dbo.ID,
                RoleID = dbo.RoleID,
                ShopID = dbo.ShopID,
                FirstName = dbo.FirstName,
                LastName = dbo.LastName,
                PhoneNo = dbo.PhoneNo,
                Email = dbo.Email,
                Department = dbo.Department,
                Designation = dbo.Designation,
                Supervisor = dbo.Supervisor,
                DateOfBirth = dbo.DateOfBirth,
                Address = dbo.Address,
                PhotoPath = dbo.PhotoPath,
                UserName = dbo.UserName,
                Password = dbo.Password,
                IsActive = dbo.IsActive,
                IsDefault = dbo.IsDefault,
                IsDeleted = dbo.IsDeleted
            };
            return ret;
        }
    
    }
}
