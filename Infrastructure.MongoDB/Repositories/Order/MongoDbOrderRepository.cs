using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories.Order
{
    public class MongoDbOrderRepository : MongoRepositoryBase<Entities.Order>, IOrderRepository
    {
        public MongoDbOrderRepository(MongoDBService _mongoDB) : base(_mongoDB)
        {
        }
    }
}
