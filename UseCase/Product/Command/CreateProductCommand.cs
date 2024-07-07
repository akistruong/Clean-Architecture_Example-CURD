using InterfaceAdapter.Product;
using MediatR;

namespace UseCase.Product.Command
{
    public class CreateProductCommand : IRequest
    {
        public ProductInsertRequest request;

        public CreateProductCommand(ProductInsertRequest request)
        {
            this.request = request;
        }
    }
}
