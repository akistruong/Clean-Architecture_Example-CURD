using Entities.Respositories;
using Infrastructure.MySQL.Repositories;
using Infrastructure.MySQL.UnitOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Product.UnitOfWork;

namespace Infrastructure.MySQL.UnitOfWork.Product
{
    public class CreateProductUnitOfWork :UnitOfWorkBase, ICreateProductUnitOfWork
    {
        public IProductRepository _productRepository { get; }
        public IIventoryRepository _iventoryRepository { get; }
        public CreateProductUnitOfWork(OrderDbContext orderDbContext):base(orderDbContext) 
        {
           this._productRepository = new ProductRepository(orderDbContext);
           this._iventoryRepository = new IventoryRepository(orderDbContext);
        }
    }
}
