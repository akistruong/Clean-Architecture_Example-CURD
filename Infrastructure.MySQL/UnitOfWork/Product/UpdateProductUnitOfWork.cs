using Infrastructure.MySQL.UnitOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interfaces.Respositories;
using UseCase.Interfaces.UnitOfWork.Product;

namespace Infrastructure.MySQL.UnitOfWork.Product
{
    public class UpdateProductUnitOfWork : UnitOfWorkBase, IUpdateProductUnitOfWork
    {
        public UpdateProductUnitOfWork(OrderDbContext orderDbContext, IProductRepository productRepository, IIventoryRepository iventoryRepository) : base(orderDbContext)
        {
            _productRepository = productRepository;
            _iventoryRepository = iventoryRepository;
        }
        public IProductRepository _productRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
    }
}
