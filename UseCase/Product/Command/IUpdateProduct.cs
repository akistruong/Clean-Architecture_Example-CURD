using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;

namespace UseCase.Product.Command
{
    public interface IUpdateProduct
    {
        public Task Update(ProductRequest request);
    }
}
