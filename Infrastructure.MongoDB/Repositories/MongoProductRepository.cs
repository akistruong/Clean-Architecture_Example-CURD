using Entities.Dtos;
using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories
{
    public class MongoProductRepository : MongoRepositoryBase<Entities.Product>, IProductRepository
    {
       

        public MongoProductRepository(MongoDBService _mongoDB) : base(_mongoDB)
        {
        }

        public Task<IEnumerable<Entities.Product>> SelectAsync(ProductQueryParams _params)
        {
            throw new NotImplementedException();
        }
    }
}
