using Entities.Respositories;
using Infrastructure.MySQL.UnitOfWork.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using UseCase.Dtos;
using UseCase.Order;
using UseCase.Order.Commands;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository _orderRepository;  
        IPlaceOrder  _placeOrder;

        public OrderController(IOrderRepository orderRepository, IPlaceOrder placeOrder)
        {
            _orderRepository = orderRepository;
            _placeOrder = placeOrder;
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
            var result = await _placeOrder.CreateOrder(request);
            
            return Ok((OrderResult)result);
        }

    }
}
