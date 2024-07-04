using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Product.Command
{
    public interface IDeleteProduct
    {
        public Task Delete(string ID);
    }
}
