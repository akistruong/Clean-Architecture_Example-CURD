using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Shared;

namespace UseCase.Product.Command
{
    public class DeleteProductCommand:IRequest<Result>
    {
        public string Id { get; set; }

        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}
