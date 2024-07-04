using AutoMapper;
using Entities.Dtos;
using Entities.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UseCase.Dtos;
using UseCase.Product;
using UseCase.Product.Command;
using UseCase.Product.Query;

namespace Web.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICreateProduct _createProduct;
        private IProductQuery _productQuery;
        private IUpdateProduct _updateProduct;
        private IDeleteProduct _deleteProduct;  
        public ProductController(ICreateProduct createProduct, IProductQuery productQuery, IUpdateProduct updateProduct, IDeleteProduct deleteProduct)
        {
            _createProduct = createProduct;
            _productQuery = productQuery;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ProductQueryParams _params)
        {
            var products = await _productQuery.ProductQuery(_params);
            int initialThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Get Thread ID: {initialThreadId}");
            return Ok(products);
        }
        [HttpPost]  
        public async Task<IActionResult> Post(ProductRequest request)
        {
            await _createProduct.Create(request);
            return Ok("Tao product thanh cong");
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(ProductRequest request)
        {
           await _updateProduct.Update(request);
            return Ok(request);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string ID)
        {
            await _deleteProduct.Delete(ID);
            return Ok();
        }
    }
}
