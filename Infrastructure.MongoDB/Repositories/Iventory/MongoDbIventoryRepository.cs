using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories.Iventory
{
    public class MongoDbIventoryRepository : MongoRepositoryBase<Entities.Iventory>, IIventoryRepository
    {
        public MongoDbIventoryRepository(MongoDBService _mongoDB) : base(_mongoDB)
        {
        }

        public Task<Entities.Iventory> GetIventoryByProductID(string productID)
        {
            throw new NotImplementedException();
        }
    }
}
