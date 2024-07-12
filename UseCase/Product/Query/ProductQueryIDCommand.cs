using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Shared;

namespace UseCase.Product.Query
{
    public record ProductQueryIDCommand(string ID) : IRequest<Result> { }
}
