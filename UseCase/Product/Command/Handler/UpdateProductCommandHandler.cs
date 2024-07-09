using AutoMapper;
using Entities.Respositories;
using FluentValidation;
using InterfaceAdapter.Product;
using MediatR;
using System.ComponentModel.DataAnnotations;
using UseCase.UnitOfWork.Base;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper,
        IIventoryRepository iventoryRepository,
        IValidator<Entities.Product> validator,
        IUnitOfWorkBase _unitOfWork
        ) : IRequestHandler<UpdateProductCommand>
    {
        private IMapper _mapper = mapper;
        private IProductRepository _productRepository = productRepository;
        private IIventoryRepository _iventoryRepository = iventoryRepository;
        private IValidator<Entities.Product> _validator  = validator;
        private readonly IUnitOfWorkBase unitOfWork = _unitOfWork;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var _productRequest = request._request;
            var _isQtyProductChange = false;
            try
            {
               
                //Begin Transaction
                await unitOfWork.Begin();
                var _productFinded = await _productRepository.SelectAsync(_productRequest.ProductID);
                ArgumentNullException.ThrowIfNull(_productFinded);
                _isQtyProductChange = _productFinded.Qty != _productRequest.Qty;
                var _product = _mapper.Map(_productRequest, _productFinded);
                var _validateResult = await _validator.ValidateAsync(_product);
                if (!_validateResult.IsValid)
                {
                    throw new Exception();
                }
                //Handle if qty change
                await HandleIfQtyChange(_isQtyProductChange, _product);
                _productRepository.Update(_product);
                //Commit transaction
                await unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //Cancel Transaction
                await unitOfWork.Cancel();
                throw ex;
            }
        }

        private async Task HandleIfQtyChange(bool _isQtyProductChange, Entities.Product _product)
        {
            if (_isQtyProductChange)
            {
                var _iventoryFind = await _iventoryRepository.GetIventoryByProductID(_product.ProductID);
                ArgumentNullException.ThrowIfNull(_iventoryFind);
                _iventoryFind.Qty = (int)_product.Qty;
                _iventoryRepository.Update(_iventoryFind);
            }
        }
    }
}
