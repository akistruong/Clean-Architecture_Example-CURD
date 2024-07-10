using Infrastructure.SQLServer.UnitOfWork.Base;
using UseCase.Interfaces.Respositories;
using UseCase.Interfaces.UnitOfWork.Product;

namespace Infrastructure.SQLServer.UnitOfWork.Product
{
    public class UpdateProductUnitOfWork : UnitOfWorkBase, IUpdateProductUnitOfWork
    {
        public UpdateProductUnitOfWork(SQLServerDbContext orderDbContext, IProductRepository productRepository, IIventoryRepository iventoryRepository) : base(orderDbContext)
        {
            _productRepository = productRepository;
            _iventoryRepository = iventoryRepository;
        }

        public IProductRepository _productRepository { get; }

        public IIventoryRepository _iventoryRepository { get; }
    }
}
