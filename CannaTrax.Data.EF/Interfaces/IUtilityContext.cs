using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Interfaces
{
    public interface IUtilityContext
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        DbContextTransaction BeginTransaction();
        int SaveChanges();
        DbRawSqlQuery SqlQuery(Type elementType, string sql, params object[] parameters);
        DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        int ExecuteSqlCommand(string sql, params object[] parameters);
        void SetAutoDetectChanges(bool enabled);
    }
}
