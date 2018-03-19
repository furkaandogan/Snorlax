using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Snorlax.Repository
{
    public class Document
        : IDocument
    {
        [BsonId]
        // [Key]
        public string Id { get; set; }
    }
}