using MediatR;
using UseCase.Interfaces.Respositories;

namespace UseCase.Product.Command.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ID = request.Id;
                var product = await _productRepository.SelectAsync(ID);
                ArgumentNullException.ThrowIfNull(product);
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
