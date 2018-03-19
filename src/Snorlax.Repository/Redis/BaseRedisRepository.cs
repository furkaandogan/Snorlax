using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snorlax.Repository.Redis
{
    public abstract class BaseRedisRepository<T, Context>
        : IRepository<T> where T : class, IDocument
                         where Context : IRedisContext
    {
        public Task AddOneAsync(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}