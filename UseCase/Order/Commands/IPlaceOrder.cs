
using UseCase.UnitOfWork.Order;
using UseCase.Dtos;

namespace UseCase.Order.Commands
{
    public interface IPlaceOrder
    {
        public ICreateOrderUnitOfWork _createOrderUnitOfWork { get; }
        public Task<OrderResult> CreateOrder(OrderRequest request);
    }
}
