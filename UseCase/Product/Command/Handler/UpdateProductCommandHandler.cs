using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Interfaces.UnitOfWork.Product;
using UseCase.Shared;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProductCommandHandler(
        IMapper mapper,
        IValidator<UpdateProductCommand> validator,
        IUpdateProductUnitOfWork updateProductUnitOfWork
        ) : IRequestHandler<UpdateProductCommand, Result>
    {
        private IMapper _mapper = mapper;
        private IValidator<UpdateProductCommand> _validator = validator;
        private readonly IUpdateProductUnitOfWork _updateProductUnitOfWork = updateProductUnitOfWork;

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var _productRequest = request;
            var _isQtyProductChange = false;
            try
            {
                //Begin Transaction
                await _updateProductUnitOfWork.Begin();
                var _validateResult = await _validator.ValidateAsync(request);
                if (!_validateResult.IsValid)
                {
                  var erros=  _validateResult.Errors;
                    return Result.Failure(new Error("Validation invalid"));
                }
                var _productFinded = await _updateProductUnitOfWork._productRepository.SelectAsync(_productRequest.ProductID);
                ArgumentNullException.ThrowIfNull(_productFinded);
                _isQtyProductChange = _productFinded.Qty != _productRequest.Qty;
                var _product = _mapper.Map(_productRequest, _productFinded);

                //Handle if qty change
                if (_isQtyProductChange) await HandleIfQtyChange(_product);
                _updateProductUnitOfWork._productRepository.Update(_product);
                //Commit transaction
                await _updateProductUnitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                //Cancel Transaction
                await _updateProductUnitOfWork.Cancel();
                throw ex;
            }
        }
        private async Task HandleIfQtyChange(Entities.Product _product)
        {
            var _iventoryFind = await _updateProductUnitOfWork._iventoryRepository.GetIventoryByProductID(_product.ProductID);
            ArgumentNullException.ThrowIfNull(_iventoryFind);
            _iventoryFind.Qty = (int)_product.Qty;
            _updateProductUnitOfWork._iventoryRepository.Update(_iventoryFind);
        }
    }
}
