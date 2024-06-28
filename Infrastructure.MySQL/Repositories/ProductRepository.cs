using Entities;
using Entities.Dtos;
using Entities.Respositories;
using Infrastructure.MySQL.Repositories.Base;
using Infrastructure.MySQL.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySQL.Repositories
{
    public class ProductRepository : RepositoryBase<Entities.Product>, IProductRepository
    {
        OrderDbContext _context;
        public ProductRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            Console.WriteLine("DbContext:ProductRepository" + orderDbContext.GetHashCode().ToString());
            _context = orderDbContext;  
        }

        public async Task<IEnumerable<Entities.Product>> SelectAsync(ProductQueryParams _params)
        {
            IQueryable<Entities.Product> products = _context.Products;
            if (_params.MinPrice >= 0 && _params.MaxPrice > 0)
            {
                products = (IQueryable<Entities.Product>)products
                .Where(x => x.ProductPrice >= _params.MinPrice)
                .Where(x => x.ProductPrice <= _params.MaxPrice);
            }
            if (_params.ProductName.Length > 0)
            {
                var _productName = _params.ProductName.ToLower().Trim();
                products = products.Where(x => x.ProductName.ToLower().Trim().Contains(_productName));
            }
            return await products.ToListAsync();
        }
    }
}
