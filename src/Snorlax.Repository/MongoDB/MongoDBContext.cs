using System;
using System.Linq;
using MongoDB.Driver;

namespace Snorlax.Repository.MongoDB
{
    public sealed class MongoDBContext
        : BaseDBContext,IMongoDBContext
    {
        private readonly IMongoDBContextConfig _contextConfig;
        public MongoDBContext(IMongoDBContextConfig contextConfig)
        {
            if(contextConfig is null)
                throw new ArgumentNullException(nameof(contextConfig));

            _contextConfig=contextConfig;
            Client=new MongoClient(contextConfig.ToConnectionString());
            Database=Client.GetDatabase(contextConfig.DatabaseName);
        }
        public IMongoClient Client {get;}

        public IMongoDatabase Database {get;}

        public IMongoCollection<T> GetCollection<T>(string collectionName=null)
            where T:class,IDocument
        {
            if(Database is null)
                throw new NullReferenceException(nameof(Database));
            return Database.GetCollection<T>(GetCollectionName(typeof(T),collectionName));
        }
    }
}