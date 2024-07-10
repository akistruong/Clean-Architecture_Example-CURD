using UseCase.Interfaces.Respositories;
using UseCase.UnitOfWork.Base;

namespace UseCase.UnitOfWork.Order
{
    public interface ICreateOrderUnitOfWork : IUnitOfWorkBase
    {
        IProductRepository _productRepository { get; }
        IOrderRepository _orderRepository { get; }
        IIventoryRepository _iventoryRepository { get; }

    }
}
