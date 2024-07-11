using UseCase.Dtos;
using UseCase.Interfaces.Respositories.Base;

namespace UseCase.Interfaces.Respositories
{
    public interface IProductRepository : IRepositoryBase<Entities.Product>
    {
        public Task<IEnumerable<Entities.Product>> SelectAsync(ProductQueryDTO _params);
    }
}
