using MediatR;
using UseCase.Dtos;

namespace UseCase.Product.Query
{
    public class ProductQueryCommand : IRequest<IEnumerable<Entities.Product>>
    {
        public ProductQueryDTO queryParams;
        public ProductQueryCommand(ProductQueryDTO queryParams)
        {
            this.queryParams = queryParams;
        }
    }
}
