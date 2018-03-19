namespace Snorlax.Repository.MongoDB
{
    public sealed class CustomerRepository
        : BaseMongoDBRepository<Model.Customer, MongoDBContext>, ICustomerRepository
    {
        public CustomerRepository(IMongoDBContext dbContext) 
        : base(dbContext)
        {
        }
    }
}