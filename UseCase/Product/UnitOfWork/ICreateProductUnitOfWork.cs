using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Base;

namespace UseCase.Product.UnitOfWork
{
    public interface ICreateProductUnitOfWork:IUnitOfWorkBase
    {
        IProductRepository _productRepository { get;  }
        IIventoryRepository _iventoryRepository { get;  }
    }
}
