using Entities;
using MediatR;

namespace UseCase.Order.Commands
{
    public class PlaceOrderCommand : IRequest<OrderResult>
    {
        public decimal TotalOrder { get; set; }
        public decimal TotalQty { get; set; }
        public string? EmailOrder { get; set; }
        public List<Entities.OrderItem> Items { get; set; }
    }
}
