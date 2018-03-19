using System.Linq;
using System.Threading.Tasks;
using Snorlax.Repository.Model;
using MongoDB.Driver;

namespace Snorlax.Repository.MongoDB
{
    // kullanıcı regis edilirken ve login edilirken parolası şifrelenmeli fakat demo olduğu içim yapmadım.
    public sealed class AdminRepository
        : BaseMongoDBRepository<Model.Admin, MongoDBContext>, IAdminRepository
    {
        public AdminRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
        
        }
        public async Task<Admin> LoginAsync(string email, string password)
        {
            var query = new FilterDefinitionBuilder<Model.Admin>().And(
                new FilterDefinitionBuilder<Model.Admin>().Eq(x=>x.Email,email),
                new FilterDefinitionBuilder<Model.Admin>().Eq(x=>x.Password,password)
            );
            return await DBContext.GetCollection<Model.Admin>()
                .FindSync<Model.Admin>(query).FirstOrDefaultAsync();
        }
    }
}