using System.Collections.Generic;
using System.Threading.Tasks;
using Snorlax.Repository.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Snorlax.Repository.MongoDB
{
    public sealed class CategoryRepository
        : BaseMongoDBRepository<Model.Category, MongoDBContext>, ICategoryRepository
    {
        public CategoryRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
        }   
        public async Task<IEnumerable<Category>> GetListWithPaginationAsync(int pageIndex, int pageSize)
        {
            return await DBContext.GetCollection<Category>()
                .AsQueryable().Skip((pageIndex*pageSize))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<bool> ExistsByIdAsync(string id)
        {
            return (await ExistsAsync(x=>x.Id==id));
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return (await ExistsAsync(x=>x.Name==name));
        }
    }
}