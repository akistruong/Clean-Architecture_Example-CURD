﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCase.Dtos;
using UseCase.Product.Command;
using UseCase.Product.Query;

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
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateProductCommand request)
        {
            await _mediator.Send(request);
            return Ok(request);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string ID)
        {
            await _mediator.Send(new DeleteProductCommand(ID));
            return Ok();
        }
    }
}
