using Entities.Respositories;
using Infrastructure.SQLServer.Repositories;
using Infrastructure.SQLServer.UnitOfWork.Base;
using UseCase.UnitOfWork.Order;

namespace Infrastructure.SQLServer.UnitOfWork.Order
{
    public class CreateOrderUnitOfWork : UnitOfWorkBase, ICreateOrderUnitOfWork
    {
        public IProductRepository _productRepository { get; }

        public IOrderRepository _orderRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
        public CreateOrderUnitOfWork(SQLServerDbContext orderDbContext, IProductRepository productRepository, IOrderRepository orderRepository, IIventoryRepository iventoryRepository) : base(orderDbContext)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _iventoryRepository = iventoryRepository;
        }


    }
}
