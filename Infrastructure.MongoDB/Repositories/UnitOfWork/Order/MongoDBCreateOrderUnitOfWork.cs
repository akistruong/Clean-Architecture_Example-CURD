using Entities.Respositories;
using Infrastructure.MongoDB.Data;
using Infrastructure.MongoDB.Repositories.UnitOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Order;

namespace Infrastructure.MongoDB.Repositories.UnitOfWork.Order
{
    public class MongoDBCreateOrderUnitOfWork : MongoDBUnitOfWorkBase, ICreateOrderUnitOfWork
    {
        public MongoDBCreateOrderUnitOfWork(MongoDBService mongoDB) : base(mongoDB)
        {
        }

        public IProductRepository _productRepository { get; }

        public IOrderRepository _orderRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
    }
}
