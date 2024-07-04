using Entities.Respositories;
using Infrastructure.MySQL.UnitOfWork.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using UseCase.Dtos;
using UseCase.Order;
using UseCase.Order.Commands;
using UseCase.Order.Commands.Handlers;

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
        public  async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.SelectAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest request)
        {
            var result = await _mediator.Send(new PlaceOrderCommand(request));
            
            return Ok((OrderResult)result);
        }

    }
}
