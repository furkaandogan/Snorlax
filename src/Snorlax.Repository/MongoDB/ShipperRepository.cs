namespace Snorlax.Repository.MongoDB
{
    public sealed class ShipperRepository
        : BaseMongoDBRepository<Model.Shipper, MongoDBContext>
    {
        public ShipperRepository(IMongoDBContext dbContext) 
            : base(dbContext)
        {
        }
    }
}