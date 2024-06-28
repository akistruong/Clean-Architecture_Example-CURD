using Entities.Respositories;
using Infrastructure.MySQL.Repositories;
using Infrastructure.MySQL.UnitOfWork.Base;

using UseCase.UnitOfWork.Order;

namespace Infrastructure.MySQL.UnitOfWork.Order
{
    public class CreateOrderUnitOfWork : UnitOfWorkBase, ICreateOrderUnitOfWork
    {
        public IProductRepository _productRepository { get; }

        public IOrderRepository _orderRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
        public CreateOrderUnitOfWork(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this._iventoryRepository = new IventoryRepository(orderDbContext);  
            this._productRepository = new ProductRepository(orderDbContext);
            this._orderRepository = new OrderRepository(orderDbContext);    
        }

     
    }
}
