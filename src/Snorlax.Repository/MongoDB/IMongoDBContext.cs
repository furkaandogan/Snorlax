using MongoDB.Driver;

namespace Snorlax.Repository.MongoDB
{
    public interface IMongoDBContext
    {
        IMongoClient Client{get;}
        IMongoDatabase Database{get;}

        IMongoCollection<T> GetCollection<T>(string collectionName=null) 
             where T:class,IDocument;

    }
}