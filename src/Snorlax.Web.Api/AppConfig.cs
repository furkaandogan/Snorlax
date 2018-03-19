using System;
using System.Text;
using AutoMapper;

namespace Snorlax.Web.Api
{
    public class AppConfig
    {
        public class MongoDbContextConfig
            : Repository.MongoDB.IMongoDBContextConfig
        {
            public MongoDbContextConfig()
            {
                Host=Environment.GetEnvironmentVariable("mongoDbHost").ToString();
                DatabaseName=Environment.GetEnvironmentVariable("mongoDbName").ToString();
                Username=Environment.GetEnvironmentVariable("mongoDbUseername").ToString();
                Password=Environment.GetEnvironmentVariable("mongoDbPassword").ToString();
                Port=int.Parse(Environment.GetEnvironmentVariable("mongoDbPort").ToString());
            }

            public string Host { get; set; }
            public string DatabaseName { get; set; }
            public string Username{ get; set; }
            public string Password { get; set; }
            public int Port { get; set; }

            public string ToConnectionString()
            {
                return string.Format("mongodb://{0}:{1}",this.Host,this.Port);
                //return string.Format("mongodb://{0}:{1}@{2}:{3}/{4}",this.Username,this.Password,this.Host,this.Port,this.DatabaseName);
            }
        }
         public class SQLDbContextConfig
            : Repository.SQLDB.ISQLDBContextConfig
        {
            public SQLDbContextConfig()
            {
                Host=Environment.GetEnvironmentVariable("sqlDbHost").ToString();
                DatabaseName=Environment.GetEnvironmentVariable("sqlDbName").ToString();
                Username=Environment.GetEnvironmentVariable("sqlDbUseername").ToString();
                Password=Environment.GetEnvironmentVariable("sqlDbPassword").ToString();
                Port=int.Parse(Environment.GetEnvironmentVariable("sqlDbPort").ToString());
            }
            public string Host { get; set; }
            public string DatabaseName { get; set; }
            public string Username{ get; set; }
            public string Password { get; set; }
            public int Port { get; set; }

            public string ToConnectionString()
            {
                return string.Format("Data Source={0},{1}; Initial Catalog={2};User ID={3};Password={4};",this.Host,this.Port.ToString(),this.DatabaseName,this.Username,this.Password);
            }
        }

        public class MappingProfile
            : Profile
        {
            protected MappingProfile()
            {
                CreateMap<Repository.Model.Product,Core.Model.Product>();
                CreateMap<Repository.Model.Category,Core.Model.Category>();
                CreateMap<Repository.Model.Supplier,Core.Model.Supplier>();
            }
        }

        public readonly string ValidIssuer;
        public readonly string ValidAudience;
        public readonly string SeckretKey;

        public AppConfig()
        {
            ValidIssuer="api.muhammetfurkandogan.com";
            ValidAudience="wwww.muhammetfurkandogan.com";
            SeckretKey="hşşş kimse duymasın bu gizli bir keydir :)";
        }

        public static void Build(){
            _current=new AppConfig();
        }

        private static AppConfig _current;
        public static AppConfig Current
        {
            get{
                if(_current==null){
                    _current=new AppConfig();
                }
                return _current;
            }
        }
    }
}