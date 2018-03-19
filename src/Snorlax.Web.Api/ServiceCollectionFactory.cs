using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Snorlax.Web.Api
{
    public static class AppFactory
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Repository.IAdminRepository,Repository.MongoDB.AdminRepository>();
            serviceCollection.AddSingleton<Repository.ICategoryRepository,Repository.MongoDB.CategoryRepository>();
            serviceCollection.AddSingleton<Repository.ICustomerRepository,Repository.MongoDB.CustomerRepository>();
            serviceCollection.AddSingleton<Repository.IEmployeeRepository,Repository.MongoDB.EmployeeRepository>();
            serviceCollection.AddSingleton<Repository.IProductRepository,Repository.MongoDB.ProductRepository>();
            serviceCollection.AddSingleton<Repository.ISupplierRepository,Repository.MongoDB.SupplierRepository>();

            serviceCollection.AddSingleton<Repository.IOrderRepository,Repository.SQLDB.OrderRepository>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterDBContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Repository.MongoDB.IMongoDBContext,Repository.MongoDB.MongoDBContext>();
            serviceCollection.AddSingleton<Repository.SQLDB.ISQLDBContext,Repository.SQLDB.SQLDBContext>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Repository.MongoDB.IMongoDBContextConfig,AppConfig.MongoDbContextConfig>();
            serviceCollection.AddSingleton<Repository.SQLDB.ISQLDBContextConfig,AppConfig.SQLDbContextConfig>();
            return serviceCollection;
        }
        public static IServiceCollection RegisterTools(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Utilities.ILogger,Utilities.ConsoleLogger>();
            // serviceCollection.AddAutoMapper();
            return serviceCollection;
        }
    }
}