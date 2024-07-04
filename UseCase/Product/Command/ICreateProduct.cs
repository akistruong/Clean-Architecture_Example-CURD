using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;
using UseCase.Product.UnitOfWork;

namespace UseCase.Product.Command
{
    public interface ICreateProduct
    {
        ICreateProductUnitOfWork _createProductUnitOfWork { get; }
        public Task<HttpStatusCode> Create(ProductRequest request);
    }
}
