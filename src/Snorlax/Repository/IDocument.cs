using MongoDB.Bson;

namespace Snorlax.Repository
{
    public interface IDocument
    {
        //ObjectId Id {get;set;}
        string Id{get;set;}
    }
}