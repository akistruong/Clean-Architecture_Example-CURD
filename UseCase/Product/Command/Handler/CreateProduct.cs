using AutoMapper;
using Entities;
using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;
using UseCase.Product.Command;
using UseCase.Product.UnitOfWork;

namespace UseCase.Product.Command.Handler
{
    public class CreateProduct : ICreateProduct
    {
        public ICreateProductUnitOfWork _createProductUnitOfWork { get; }
        IMapper _mapper;
        public CreateProduct(ICreateProductUnitOfWork productUnitOfWork, IMapper mapper)
        {
            _createProductUnitOfWork = productUnitOfWork;
            _mapper = mapper;
        }
        public async Task<HttpStatusCode> Create(ProductRequest request)
        {
            try
            {
                await _createProductUnitOfWork.Begin();
                var _productAdd = _mapper.Map<Entities.Product>(request);
                if (_productAdd.Qty <= 0)
                {
                    throw new Exception("Co loi xay ra");
                }
                //Insert product
                await _createProductUnitOfWork._productRepository.InsertAsync(_productAdd);
                // New Iventory
                var _iventory = new Iventory()
                {
                    ID = Guid.NewGuid().ToString(),
                    ProductID = request.ProductID,
                    Qty = request.Qty,
                };
                //Insert Iventory
                await _createProductUnitOfWork._iventoryRepository.InsertAsync(_iventory);
                await _createProductUnitOfWork.Commit();
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _createProductUnitOfWork.Cancel();
                throw ex;
            }
        }
    }
}
