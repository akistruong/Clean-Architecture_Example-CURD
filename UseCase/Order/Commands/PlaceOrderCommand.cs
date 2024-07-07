using InterfaceAdapter.Order;
using MediatR;

namespace UseCase.Order.Commands
{
    public class PlaceOrderCommand : IRequest<OrderResult>
    {
        public OrderInsertRequest _request;

        public PlaceOrderCommand(OrderInsertRequest request)
        {
            _request = request;
        }
    }
}
