using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Pagination.Base;
using UseCase.Pagination.Product;

namespace Infrastructure.MySQL.Repositories.Pagination.Product
{
    public class ProductPagination:Pagination<Entities.Product>,IProductPagination
    {
    }
}
