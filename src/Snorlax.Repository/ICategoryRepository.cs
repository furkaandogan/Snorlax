using System.Collections.Generic;
using System.Threading.Tasks;
using Snorlax.Repository.Model;

namespace Snorlax.Repository
{
    public interface ICategoryRepository
        :IRepository<Model.Category>
    {
        
        Task<IEnumerable<Category>> GetListWithPaginationAsync(int pageIndex,int pageSize);
        Task<bool> ExistsByIdAsync(string id);
        Task<bool> ExistsByNameAsync(string name);
    }
}