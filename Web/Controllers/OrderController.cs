using Entities.Respositories;
using InterfaceAdapter.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCase.Order;
using UseCase.Order.Commands;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository _orderRepository;
        IMediator _mediator;

        public OrderController(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.SelectAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderInsertRequest request)
        {
            var result = await _mediator.Send(new PlaceOrderCommand(request));

            return Ok((OrderResult)result);
        }

    }
}
