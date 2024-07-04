using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;

namespace UseCase.Product.Command
{
    public class UpdateProductCommand:IRequest
    {
        public readonly ProductRequest _request;

        public UpdateProductCommand(ProductRequest request)
        {
            _request = request;
        }
    }
}
