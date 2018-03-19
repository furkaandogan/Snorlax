namespace Snorlax.Repository.SQLDB
{
    public sealed class OrderRepository
        : BaseSQLDBRepository<Model.Order, SQLDBContext>, IOrderRepository
    {
        public OrderRepository(ISQLDBContext dbContext) 
            : base(dbContext)
        {
            
        }
    }
}