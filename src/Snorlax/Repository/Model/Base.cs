using System;
using System.Runtime.Serialization;
using MongoDB.Bson;

namespace Snorlax.Repository.Model
{
    
    [DataContract]
    [Serializable]
    public abstract class Base
        : Document
    {

        public Base()
            :this(Guid.NewGuid().ToString())
        {

        }
        public Base(string id)
        {
            this.Id=id;
        }

    }
}