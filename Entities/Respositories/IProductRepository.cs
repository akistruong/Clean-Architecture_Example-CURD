using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Respositories.Base;

namespace Entities.Respositories
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        public Task<IEnumerable<Product>> SelectAsync(ProductQueryParams _params);
    }
}
