using MediatR;
using UseCase.Interfaces.Respositories;

namespace UseCase.Product.Query.Handler
{
    public class PropductQueryCommandHandler : IRequestHandler<ProductQueryCommand, IEnumerable<Entities.Product>>
    {
        private readonly IProductRepository productRepository;
        public PropductQueryCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Entities.Product>> Handle(ProductQueryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await productRepository.SelectAsync(request.queryParams);
                var _limit = request.queryParams.Limit < 0 ? 2 : request.queryParams.Limit;
                var _page = request.queryParams.Page < 1 ? 1 : request.queryParams.Page;
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
