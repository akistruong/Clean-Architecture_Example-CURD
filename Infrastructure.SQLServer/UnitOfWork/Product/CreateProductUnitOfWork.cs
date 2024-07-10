using Infrastructure.SQLServer.Repositories;
using Infrastructure.SQLServer.UnitOfWork.Base;
using UseCase.Interfaces.Respositories;
using UseCase.Product.UnitOfWork;

namespace Infrastructure.SQLServer.UnitOfWork.Product
{
    public class CreateProductUnitOfWork : UnitOfWorkBase, ICreateProductUnitOfWork
    {
        public IProductRepository _productRepository { get; }
        public IIventoryRepository _iventoryRepository { get; }
        public CreateProductUnitOfWork(SQLServerDbContext orderDbContext) : base(orderDbContext)
        {
            this._productRepository = new ProductRepository(orderDbContext);
            this._iventoryRepository = new IventoryRepository(orderDbContext);
        }
    }
}
