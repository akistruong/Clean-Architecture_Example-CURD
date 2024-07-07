using InterfaceAdapter.Product;
using MediatR;

namespace UseCase.Product.Command
{
    public class UpdateProductCommand : IRequest
    {
        public readonly ProductUpdateRequest _request;

        public UpdateProductCommand(ProductUpdateRequest request)
        {
            _request = request;
        }
    }
}
