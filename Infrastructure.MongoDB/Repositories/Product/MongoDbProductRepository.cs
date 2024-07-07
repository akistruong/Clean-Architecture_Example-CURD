using Entities.Dtos;
using Entities.Respositories;
using Entities.Respositories.Base;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories.Product
{
    public class MongoDbProductRepository : MongoRepositoryBase<Entities.Product>, IProductRepository
    {
        private readonly MongoDBService _mongoDB;
        public MongoDbProductRepository(MongoDBService _mongoDB) : base(_mongoDB)
        {
        }

        public async Task<IEnumerable<Entities.Product>> SelectAsync(ProductQueryParams _params)
        {
            var products =await  base.SelectAsync();
            return products;
        }
    }
}
