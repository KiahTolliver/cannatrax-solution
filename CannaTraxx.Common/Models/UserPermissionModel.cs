using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTraxx.Common.Models
{
    public class UserPermissionModel
    {
        public int ID { get; set; }
        public int? ModuleID { get; set; }
        public int? RoleID { get; set; }
    }
}
