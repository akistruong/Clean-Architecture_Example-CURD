using Entities.Dtos;
using MediatR;

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
