using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Pagination.Base;

namespace UseCase.Pagination.Product
{
    public interface IProductPagination : IPagination<Entities.Product>  
    {
    }
}
