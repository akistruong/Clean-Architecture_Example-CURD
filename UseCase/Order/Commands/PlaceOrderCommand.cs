using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;

namespace UseCase.Order.Commands
{
    public class PlaceOrderCommand : IRequest<OrderResult>
    {
        public OrderRequest _request;

        public PlaceOrderCommand(OrderRequest request)
        {
            _request = request;
        }
    }
}
