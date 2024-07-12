using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;

namespace UseCase.Product.Query.Handler
{
    public sealed class ProductQueryIDCommandHandler(IProductRepository _prodcutRepository) : IRequestHandler<ProductQueryIDCommand, Result>
    {

        public async Task<Result> Handle(ProductQueryIDCommand request, CancellationToken cancellationToken)
        {
            var response = await _prodcutRepository.SelectAsync(request.ID);
            if(response!=null)
            {
           return ResultT<Entities.Product>.Success(response);    
            }
            else
            {
                return Result.NotFound;
            }
        }
    }
}
