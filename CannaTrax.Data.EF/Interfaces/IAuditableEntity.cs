using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Interfaces
{
    internal interface IAuditableEntity
    {
        int? InsertedBy { get; set; }
        DateTime? InsertedDate { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
    }
}
