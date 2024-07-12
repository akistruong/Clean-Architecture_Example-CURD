using MediatR;
using UseCase.Dtos;
using UseCase.Shared;

namespace UseCase.Product.Query
{
    public class ProductQueryCommand : IRequest<Result>
    {
        public ProductQueryDTO queryParams;
        public ProductQueryCommand(ProductQueryDTO queryParams)
        {
            this.queryParams = queryParams;
        }
    }
}
