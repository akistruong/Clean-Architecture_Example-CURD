using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Product.Command
{
    public class DeleteProductCommand:IRequest
    {
        public string Id { get; set; }

        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}
