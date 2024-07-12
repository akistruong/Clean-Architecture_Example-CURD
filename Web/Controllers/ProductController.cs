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
            var _command = new ProductQueryCommand(_params);
            var _result = await _mediator.Send(_command);
            return Ok(_result);
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(string ID)
        {
            var _command = new ProductQueryIDCommand(ID);
            var _result = await _mediator.Send(_command);
            return Ok(_result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand request)
        {

            var _command = request;
            var result = await _mediator.Send(_command);
            return result._isSuccessed ? Ok(result!) : this.BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateProductCommand request)
        {
            var _command = request;
            var result = await _mediator.Send(_command);
            return result._isSuccessed ? Ok(result!) : this.BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string ID)
        {
            var _command = new DeleteProductCommand(ID);
            var result = await _mediator.Send(_command);
            return result._isSuccessed ? Ok(result!) : this.BadRequest(result);
        }
    }
}
