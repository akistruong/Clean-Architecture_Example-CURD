using Entities.Dtos;
using Entities.Respositories;
using UseCase.Pagination.Base;
using UseCase.Pagination.Product;
namespace UseCase.Product.Query.Handler
{
    public class ProductQuery : IProductQuery
    {
        public IProductRepository _productRepository;
        public IProductPagination _pagination;
        public ProductQuery(IProductRepository productRepository,
IProductPagination pagination)
        {
            _productRepository = productRepository;
            _pagination = pagination;
        }

        async Task<IEnumerable<Entities.Product>> IProductQuery.ProductQuery(ProductQueryParams queryPrams)
        {
            var products = await _productRepository.SelectAsync(queryPrams);
           products=  _pagination.Excute(products, queryPrams.Limit, queryPrams.Page);
            return products;
        }
    }
}
