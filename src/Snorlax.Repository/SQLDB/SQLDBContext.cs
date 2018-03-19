using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Snorlax.Repository.SQLDB
{
    public sealed class SQLDBContext
        : /*BaseDBContext*/ DbContext, ISQLDBContext
    {
        private readonly ISQLDBContextConfig _contextConfig;

        public SQLDBContext(ISQLDBContextConfig contextConfig)
        {
            _contextConfig=contextConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_contextConfig.ToConnectionString());
        }
        
        // public DbSet<Model.Order> Order{get;set;}

        public DbSet<T> GetDbSet<T>(string tableName = null) 
            where T:class,IDocument
        {
            return this.GetDbSet<T>(GetCollectionName(typeof(T),tableName));
        }

        private string GetCollectionName(Type type,string collectionName)
        {
            if(string.IsNullOrEmpty(collectionName))
                collectionName=GetAttributeCollectionName(type);
            return collectionName;
        }

        private string GetAttributeCollectionName(Type type)
        {
            return (type
                .GetCustomAttributes(typeof(CollectionNameAttribute),false)
                .FirstOrDefault() as CollectionNameAttribute)?.Name;
        }
    }
}