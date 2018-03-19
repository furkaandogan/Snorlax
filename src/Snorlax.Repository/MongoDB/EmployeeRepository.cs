namespace Snorlax.Repository.MongoDB
{
    public sealed class EmployeeRepository
        : BaseMongoDBRepository<Model.Employee, MongoDBContext>,IEmployeeRepository
    {
        public EmployeeRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
        }
    }
}