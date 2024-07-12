using Infrastructure.MySQL.Repositories;
using Infrastructure.MySQL.UnitOfWork.Base;
using UseCase.Interfaces.Respositories;
using UseCase.Product.UnitOfWork;

namespace Infrastructure.MySQL.UnitOfWork.Product
{
    internal class CreateProductUnitOfWork : UnitOfWorkBase, ICreateProductUnitOfWork
    {
        public IProductRepository _productRepository { get; }
        public IIventoryRepository _iventoryRepository { get; }
        public CreateProductUnitOfWork(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            this._productRepository = new ProductRepository(orderDbContext);
            this._iventoryRepository = new IventoryRepository(orderDbContext);
        }
    }
}
