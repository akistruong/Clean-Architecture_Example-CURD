using AutoMapper;
using FluentValidation;
using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;
using UseCase.Shared.ErrorsShared;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProductCommandHandler(
        IMapper _mapper,
        IValidator<UpdateProductCommand> _validator,
        IProductRepository _productRepository,
        IIventoryRepository _iventoryRepository
        ) : IRequestHandler<UpdateProductCommand, Result>
    {
        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var _productRequest = request;
            var _isQtyProductChange = false;
            var _validateResult = await _validator.ValidateAsync(request);
            if (!_validateResult.IsValid)
            {
                var erros = _validateResult.Errors;
                return Result.Failure(ErrorsShared.InvalidModel);
            }
            var _productFinded = await _productRepository.SelectAsync(_productRequest.ProductID);
            if (_productFinded == null) return Result.NotFound;
            _isQtyProductChange = _productFinded.Qty != _productRequest.Qty;
            var _product = _mapper.Map(_productRequest, _productFinded);

            //Handle if qty change
            var _iventoryFind = await _iventoryRepository.GetIventoryByProductID(_product.ProductID);
            if (_iventoryFind == null) return Result.NotFound;
            if (_isQtyProductChange) await HandleIfQtyChange(_iventoryFind, _product);
            _productRepository.Update(_product);
            return Result.Success;
        }
        private async Task HandleIfQtyChange(Entities.Iventory iventory, Entities.Product product)
        {
            iventory.Qty = (int)product.Qty;
            _iventoryRepository.Update(iventory);
        }
    }
}
