using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;

namespace UseCase.Product.Command
{
    public class CreateProductCommand:IRequest
    {
        public ProductRequest request;

        public CreateProductCommand(ProductRequest request)
        {
            this.request = request;
        }
    }
}
