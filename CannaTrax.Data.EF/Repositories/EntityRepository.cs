using CannaTrax.Data.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CannaTrax.Data.EF.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IQueryableEntity
    {
        private readonly IUtilityContext _context;
        private readonly string _username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public Expression Expression => ((IQueryable<T>)_context.Set<T>()).Expression;
        public Type ElementType => ((IQueryable<T>)_context.Set<T>()).ElementType;
        public IQueryProvider Provider => ((IQueryable<T>)_context.Set<T>()).Provider;
        public IQueryable<T> Queryable() => _context.Set<T>();
        public IQueryable<T> QueryableNoTracking() => _context.Set<T>().AsNoTracking<T>();

        public EntityRepository(IUtilityContext context)
        {
            if (context != null)
            {
                _context = context;
            }
            else
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
        public EntityRepository():this(new UtilityContext())
        {

        }
        public void Insert(T obj)
        {
            InsertMany(new List<T>() { obj });
        }

        public void InsertMany(IEnumerable<T> list)
        {
            if (list == null) { throw new ArgumentException($"{ nameof(list) } argument cannot be null"); }
            try
            {
                var listToAdd = list.Select(x =>
                {
                    UpdateAuditFields(x, false);
                    return x;
                });
                _context.Set<T>().AddRange(listToAdd);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = new List<string>();
                foreach (var validationResult in e.EntityValidationErrors)
                {
                    var entityName = validationResult.Entry.Entity.GetType().Name;
                    errorMessages.AddRange(validationResult.ValidationErrors.Select(error => entityName + "." +
                        error.PropertyName + ": " + error.ErrorMessage));
                }

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
            }

        }

        public void Update(T obj)
        {
            UpdateAuditFields(obj, true);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateMany(List<T> list, Func<T, object> propsToUpdate)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException($"{ nameof(list) } argument cannot be null or empty");
            }
            var updateListTable = new DataTable();
            var propRecord = propsToUpdate(list[0]);
            var tableName = typeof(T).Name;
            string[] propertyNames = propRecord.GetType().GetProperties().Select(p => p.Name).ToArray();
            for (var i = 0; i < propertyNames.Length; ++i)
            {
                updateListTable.Columns.Add(propertyNames[i]);
            }
            list.ForEach(record => {
                var row = updateListTable.NewRow();
                var updateRecord = propsToUpdate(record);
                for (var i = 0; i < propertyNames.Length; ++i)
                {
                    row[propertyNames[i]] = updateRecord.GetType().GetProperty(propertyNames[i]).GetValue(updateRecord);
                }
                updateListTable.Rows.Add(row);
            });
            var procedureSqlParameters = new SqlParameter[]
            {
                    new SqlParameter("updateList", updateListTable) {SqlDbType= SqlDbType.Structured, TypeName=$"trn.{tableName}UpdateList",  }
            };

            _context.ExecuteSqlCommand($"trn.Update{tableName} @updateList", procedureSqlParameters);
        }

        public void Delete(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteMany(IEnumerable<T> list)
        {
            if (list == null) { throw new ArgumentException($"{ nameof(list) } argument cannot be null"); }
            _context.Set<T>().RemoveRange(list);
            _context.SaveChanges();
        }

        public void Procedure(string sprocName, params object[] parameters)
        {
            _context.ExecuteSqlCommand(sprocName, parameters);
        }

        private void UpdateAuditFields(T obj, bool isUpdate)
        {
            if (obj is IAuditableEntity auditableEntity)
            {
                if (!isUpdate)
                {
                    auditableEntity.InsertedBy = 1;
                    auditableEntity.InsertedDate = DateTime.UtcNow;
                }
                auditableEntity.LastModifiedBy = 1;
                auditableEntity.LastModifiedDate = DateTime.UtcNow;
            }
        }

    }
}
