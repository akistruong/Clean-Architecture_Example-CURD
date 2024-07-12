using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;

namespace UseCase.Product.Query.Handler
{
    public class PropductQueryCommandHandler : IRequestHandler<ProductQueryCommand,Result>
    {
        private readonly IProductRepository productRepository;
        public PropductQueryCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Result> Handle(ProductQueryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await productRepository.SelectAsync(request.queryParams);
                return ResultT<IEnumerable<Entities.Product>>.Success(products);    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
