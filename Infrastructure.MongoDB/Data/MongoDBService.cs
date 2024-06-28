using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.MongoDB.Data
{
    public class MongoDBService
    {
        
        readonly IMongoDatabase? _database;

        public MongoDBService()
        {
            
            var _mongoURL = MongoUrl.Create("mongodb://localhost:27017/");
            var _mongoClient = new MongoClient(_mongoURL);
            _database = _mongoClient.GetDatabase("OrderModule");
        }
        public IMongoDatabase? Database => _database;
    }
}
