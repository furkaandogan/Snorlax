using System;
using System.Linq;
using MongoDB.Driver;

namespace Snorlax.Repository
{
    public abstract class BaseDBContext
        : IDBContext
    {

        protected string GetCollectionName(Type type,string collectionName)
        {
            if(string.IsNullOrEmpty(collectionName))
                collectionName=GetAttributeCollectionName(type);
            return collectionName;
        }

        protected string GetAttributeCollectionName(Type type)
        {
            return (type
                .GetCustomAttributes(typeof(CollectionNameAttribute),false)
                .FirstOrDefault() as CollectionNameAttribute)?.Name;
        }
    }
}