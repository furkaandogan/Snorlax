using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snorlax.Repository
{
    public interface IRepository<T>
        where T:class , IDocument
            
    {
        Task AddOneAsync(T model);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<bool> UpdateOneAsync(T model);
        Task<int> DeleteAsync(T model);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);
    }
}