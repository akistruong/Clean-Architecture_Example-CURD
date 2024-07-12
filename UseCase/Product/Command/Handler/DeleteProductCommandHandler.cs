using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;

namespace UseCase.Product.Command.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Result>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ID = request.Id;
                var product = await _productRepository.SelectAsync(ID);
                if (product == null) return Result.NotFound;
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
