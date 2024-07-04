using Entities.Dtos;
using Entities.Respositories;
using MediatR;
using UseCase.Dtos;
using UseCase.Pagination.Base;
using UseCase.Pagination.Product;
namespace UseCase.Product.Query.Handler
{
    public class PropductQueryCommandHandler : IRequestHandler<ProductQueryCommand,IEnumerable<Entities.Product>>
    {
        private readonly IProductRepository productRepository;
        public IProductPagination pagination;
        public PropductQueryCommandHandler(IProductRepository productRepository, IProductPagination pagination)
        {
            this.productRepository = productRepository;
            this.pagination = pagination;
        }

        public async Task<IEnumerable<Entities.Product>> Handle(ProductQueryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await productRepository.SelectAsync(request.queryParams);
                products = pagination.Excute(products, request.queryParams.Limit, request.queryParams.Page);
                return products;
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
