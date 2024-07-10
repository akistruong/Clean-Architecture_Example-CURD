using AutoMapper;
using FluentValidation;
using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.UnitOfWork.Base;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper,
        IIventoryRepository iventoryRepository,
        IValidator<UpdateProductCommand> validator,
        IUnitOfWorkBase _unitOfWork
        ) : IRequestHandler<UpdateProductCommand>
    {
        private IMapper _mapper = mapper;
        private IProductRepository _productRepository = productRepository;
        private IIventoryRepository _iventoryRepository = iventoryRepository;
        private IValidator<UpdateProductCommand> _validator = validator;
        private readonly IUnitOfWorkBase unitOfWork = _unitOfWork;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var _productRequest = request;
            var _isQtyProductChange = false;
            try
            {

                //Begin Transaction
                await unitOfWork.Begin();
                var _validateResult = await _validator.ValidateAsync(request);
                if (!_validateResult.IsValid)
                {
                    throw new Exception();
                }
                var _productFinded = await _productRepository.SelectAsync(_productRequest.ProductID);
                ArgumentNullException.ThrowIfNull(_productFinded);
                _isQtyProductChange = _productFinded.Qty != _productRequest.Qty;
                var _product = _mapper.Map(_productRequest, _productFinded);

                //Handle if qty change
                if (_isQtyProductChange) await HandleIfQtyChange(_product);
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

        private async Task HandleIfQtyChange(Entities.Product _product)
        {
            var _iventoryFind = await _iventoryRepository.GetIventoryByProductID(_product.ProductID);
            ArgumentNullException.ThrowIfNull(_iventoryFind);
            _iventoryFind.Qty = (int)_product.Qty;
            _iventoryRepository.Update(_iventoryFind);
        }
    }
}
