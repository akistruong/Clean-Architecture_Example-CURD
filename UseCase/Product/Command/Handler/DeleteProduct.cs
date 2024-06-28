using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Product.Command;

namespace UseCase.Product.Command.Handler
{
    public class DeleteProduct : IDeleteProduct
    {
        IProductRepository _productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Delete(string ID)
        {
            var _productFinded = await _productRepository.SelectAsync(ID);
            ArgumentNullException.ThrowIfNull(_productFinded);
            _productRepository.Delete(_productFinded);
            await _productRepository.SaveChangesAsync();
        }
    }
}
