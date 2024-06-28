﻿using Entities.Dtos;
using Entities.Respositories;
using Entities.Respositories.Base;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories.Product
{
    public class MongoDbProductRepository : MongoRepositoryBase<Entities.Product>, IProductRepository
    {
        public MongoDbProductRepository(MongoDBService _mongoDB) : base(_mongoDB)
        {
        }

        public Task<IEnumerable<Entities.Product>> SelectAsync(ProductQueryParams _params)
        {
            throw new NotImplementedException();
        }
    }
}
