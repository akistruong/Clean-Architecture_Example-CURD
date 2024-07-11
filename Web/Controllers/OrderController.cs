using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCase.Interfaces.Respositories;
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
        public async Task<IActionResult> CreateOrder(PlaceOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

    }
}
