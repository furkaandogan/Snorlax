using System.Threading.Tasks;

namespace Snorlax.Repository.MongoDB
{
    public sealed class SupplierRepository
        : BaseMongoDBRepository<Model.Supplier, MongoDBContext>,ISupplierRepository
    {
        public SupplierRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
            
        }
        public async Task<bool> ExistsByIdAsync(string id)
        {
            return (await ExistsAsync(x=>x.Id==id));
        }
    }
}