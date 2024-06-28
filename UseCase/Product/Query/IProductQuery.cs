using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Product.Query
{
    public interface IProductQuery
    {
        public Task<IEnumerable<Entities.Product>> ProductQuery(ProductQueryParams queryPrams);
    }
}
