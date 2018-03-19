using System.Threading.Tasks;
using System.Collections.Generic;
using Snorlax.Repository.Model;

namespace Snorlax.Repository
{
    public interface IProductRepository
        :IRepository<Repository.Model.Product>
    {
        Task<IEnumerable<Product>> GetListWithPaginationAsync(int pageIndex,int pageSize);
    }
}