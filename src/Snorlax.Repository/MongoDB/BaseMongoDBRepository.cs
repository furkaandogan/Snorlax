using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Snorlax.Repository.MongoDB
{
    public abstract class BaseMongoDBRepository<T,Context>
        : IRepository<T> where T : class , IDocument
                         where Context: IMongoDBContext
    {
        protected IMongoDBContext DBContext{get;private set;}
        public BaseMongoDBRepository(IMongoDBContext dbContext)
        {
            DBContext=(MongoDBContext)dbContext;
        }
        #region insert
        
        public virtual async Task AddOneAsync(T model)
        {
           await DBContext.GetCollection<T>().InsertOneAsync(model);
        }

        #endregion

        #region update
        
        public virtual async Task<bool> UpdateOneAsync(T model)
        {
            return (await DBContext
                .GetCollection<T>()
                .ReplaceOneAsync(x=>x.Id==model.Id,model)).ModifiedCount==1;
        }

        #endregion

        public virtual async Task<int> DeleteAsync(T model)
        {
            return int.Parse((await DBContext
                .GetCollection<T>()
                .DeleteManyAsync(x=>x.Id==model.Id)).DeletedCount.ToString());
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return (await DBContext.GetCollection<T>().AsQueryable().AnyAsync(predicate));
        }
        public virtual async Task<int> CountAsync()
        {
            return (await DBContext.GetCollection<T>().AsQueryable().CountAsync());
        }
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return (await DBContext.GetCollection<T>().AsQueryable().CountAsync(predicate));
        }
        public virtual async  Task<T> GetByIdAsync(string id)
        {
            var query = new global::MongoDB.Driver.FilterDefinitionBuilder<T>()
                .Eq(x=>x.Id,id);
            return await DBContext
                .GetCollection<T>()
                .FindAsync<T>(query).Result.FirstOrDefaultAsync();
            
        }
    }
}