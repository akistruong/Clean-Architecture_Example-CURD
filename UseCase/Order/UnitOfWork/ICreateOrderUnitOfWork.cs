using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Base;

namespace UseCase.UnitOfWork.Order
{
    public interface ICreateOrderUnitOfWork:IUnitOfWorkBase
    {
         IProductRepository _productRepository { get; }
         IOrderRepository _orderRepository { get; }
         IIventoryRepository _iventoryRepository { get; }

    }
}
