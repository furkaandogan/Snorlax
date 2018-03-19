using System.Collections.Generic;
using System.Threading.Tasks;
using Snorlax.Repository.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Snorlax.Repository.MongoDB
{
    public sealed class ProductRepository
        : BaseMongoDBRepository<Model.Product, MongoDBContext>,IProductRepository
    {
        public ProductRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetListWithPaginationAsync(int pageIndex, int pageSize)
        {
            return await DBContext.GetCollection<Product>()
                .AsQueryable().Skip((pageIndex*pageSize))
                .Take(pageSize)
                .ToListAsync();
        }
    }
}