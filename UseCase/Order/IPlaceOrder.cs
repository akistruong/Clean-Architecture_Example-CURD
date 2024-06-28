using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Order;
using UseCase.Dtos;
using UseCase.UnitOfWork.Order;

namespace UseCase.Order
{
    public interface IPlaceOrder
    {
        public ICreateOrderUnitOfWork _createOrderUnitOfWork { get; }
        public Task<OrderResult> CreateOrder(OrderRequest request);
    }
}
