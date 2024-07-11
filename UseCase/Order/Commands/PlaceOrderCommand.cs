using MediatR;
using UseCase.OrderItem;
using UseCase.Shared;

namespace UseCase.Order.Commands
{
    public class PlaceOrderCommand : IRequest<Result>
    {
        public decimal TotalOrder { get; set; }
        public decimal TotalQty { get; set; }
        public string? EmailOrder { get; set; }
        public List<OrderItemCommand> Items { get; set; }
    }
}
