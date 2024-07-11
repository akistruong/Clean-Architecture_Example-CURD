using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interfaces.Respositories;
using UseCase.Interfaces.UnitOfWork.Base;

namespace UseCase.Interfaces.UnitOfWork.Product
{
    public interface IUpdateProductUnitOfWork:IUnitOfWorkBase
    {
        public IProductRepository _productRepository { get; }
        public IIventoryRepository _iventoryRepository { get; }
    }
}
