using CannaTrax.Data.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public interface IEntityRepository<T> where T : IQueryableEntity
    {
        IQueryable<T> Queryable();
        IQueryable<T> QueryableNoTracking();
        void Update(T obj);
        void UpdateMany(List<T> list, Func<T, object> propsToUpdate);
        void Insert(T obj);
        void InsertMany(IEnumerable<T> list);
        void Delete(T obj);
        void DeleteMany(IEnumerable<T> list);
        void Procedure(string sprocName, params object[] parameters);
    }
}
