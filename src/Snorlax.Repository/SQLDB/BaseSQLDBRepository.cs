using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Snorlax.Repository.SQLDB
{
    public abstract class BaseSQLDBRepository<T,Context>
        : IRepository<T> where T : class ,IDocument
                         where Context: ISQLDBContext
    {
        protected SQLDBContext DBContext{get;private set;}
        public BaseSQLDBRepository(ISQLDBContext dbContext)
        {
            DBContext=(SQLDBContext)dbContext;
        }
        #region insert
        
        public virtual async Task AddOneAsync(T model)
        {
            await DBContext.GetDbSet<T>().AddAsync(model);
        }

        #endregion

        #region update
        
        public virtual async Task<bool> UpdateOneAsync(T model)
        {
            T findObject= await DBContext.GetDbSet<T>().FindAsync(model.Id);
            if(findObject!=null)
                DBContext.Entry(findObject).CurrentValues.SetValues(model);
                
            return await DBContext.SaveChangesAsync()==1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(T model)
        {
            DBContext.Set<T>().Remove(model);
            return await DBContext.SaveChangesAsync();
        }

        
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return (await DBContext.GetDbSet<T>().AnyAsync<T>(predicate));
        }


        public virtual async Task<int> CountAsync()
        {
            return (await DBContext.GetDbSet<T>().CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return (await DBContext.GetDbSet<T>().CountAsync(predicate));
        }

        public virtual async  Task<T> GetByIdAsync(string id)
        {
            return (await DBContext.GetDbSet<T>().FirstOrDefaultAsync(x=>x.Id.ToString()==id));
        }

       
    }
}