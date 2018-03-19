using System;

namespace Snorlax.Repository
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CollectionNameAttribute : Attribute,ICollectionName
    {
        private readonly string _collectionName;
        
        public CollectionNameAttribute(string name)
        {
            this._collectionName = name;
        }
        

        public string Name {
            get
            {
                return _collectionName;
            }
        }
    }
}