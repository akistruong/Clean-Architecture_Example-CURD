using AutoMapper;
using Entities;
using Entities.Respositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UseCase.Product.UnitOfWork;

namespace UseCase.Product.Command.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private ICreateProductUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateProductCommandHandler(ICreateProductUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
               
                await _unitOfWork.Begin();
                var _productAdd = _mapper.Map<Entities.Product>(request.request);
                if (_productAdd.Qty <= 0)
                {
                    throw new Exception("Co loi xay ra");
                }
                //Insert product
                await _unitOfWork._productRepository.InsertAsync(_productAdd);
                // New Iventory
                var _iventory = new Iventory()
                {
                    ID = Guid.NewGuid().ToString(),
                    ProductID = request.request.ProductID,
                    Qty = request.request.Qty,
                };
                //Insert Iventory
                await _unitOfWork._iventoryRepository.InsertAsync(_iventory);
                await _unitOfWork.Commit();
                
            }
            catch (Exception ex)
            {
                await _unitOfWork.Cancel();
                throw ex;
            }
        }
    }
}
