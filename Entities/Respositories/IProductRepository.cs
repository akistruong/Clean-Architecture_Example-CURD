using Entities.Dtos;
using Entities.Respositories.Base;

namespace Entities.Respositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public Task<IEnumerable<Product>> SelectAsync(ProductQueryParams _params);
    }
}
