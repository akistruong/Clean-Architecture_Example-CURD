using MediatR;
using UseCase.Dtos;

namespace UseCase.Product.Query
{
    public class ProductQueryCommand : IRequest<IEnumerable<Entities.Product>>
    {
        public ProductQueryParams queryParams;
        

        public ProductQueryCommand(ProductQueryParams queryParams)
        {
            this.queryParams = queryParams;
        }
    }
}
