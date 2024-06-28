using Entities;
using Entities.Respositories;
using Moq;
using System.Net;
using UseCase;
using NUnit;
using NUnit.Framework;
namespace UseCaseTest
{
    
    public class CreateProductTest
    {
        [Test]
        public async void CreateProductFaild()
        {
            var _productRepository = new Mock<IProductRepository>();
            var _iventoryRepository = new Mock<IIventoryRepository>();
            var createProductRepo = new CreateProduct(_productRepository.Object, _iventoryRepository.Object);
            var p = new Product()
            {

                IsStock = true,
                ProductName = "Test",
                Qty = 0,
                ProductPrice = 100,
                ProductID="SP09"
            };
           var result =await  createProductRepo.Create(p);
            NUnit.Framework.Assert.Equals(HttpStatusCode.MultiStatus, result);    
        }
    }
}