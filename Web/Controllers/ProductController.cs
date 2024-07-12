using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Serilog;
using UseCase.Dtos;
using UseCase.Product.Command;
using UseCase.Product.Query;
using UseCase.Shared;

namespace Web.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductQueryDTO _params)
        {
            var products = await _mediator.Send(new ProductQueryCommand(_params));
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand request)
        {
           
            var result = await _mediator.Send(request);
            return result._isSuccessed ? Ok(result!) : this.BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateProductCommand request)
        {
            var result =  await _mediator.Send(request);
            return result._isSuccessed? Ok(result!): this.BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string ID)
        {
            await _mediator.Send(new DeleteProductCommand(ID));
            return Ok();
        }
    }
}
