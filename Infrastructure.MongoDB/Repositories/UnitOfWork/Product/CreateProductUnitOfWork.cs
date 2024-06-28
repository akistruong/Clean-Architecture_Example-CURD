using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.Iventory;
using Infrastructure.MongoDB.Repositories.Product;
using Infrastructure.MongoDB.Repositories.UnitOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Product.UnitOfWork;

namespace Infrastructure.MongoDB.Repositories.UnitOfWork.Product
{
    public class MongoDbCreateProductUnitOfWork : MongoDBUnitOfWorkBase, ICreateProductUnitOfWork
    {
        public MongoDbCreateProductUnitOfWork(MongoDBService mongoDB) : base(mongoDB)
        {
            this._iventoryRepository = new MongoDbIventoryRepository(mongoDB);   
            this._productRepository = new MongoDbProductRepository(mongoDB);    
        }
        public IProductRepository _productRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
    }
}
