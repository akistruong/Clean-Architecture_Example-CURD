using AutoMapper;
using Entities;
using FluentValidation;
using MediatR;
using UseCase.Interfaces.Respositories;
using UseCase.Shared;
using UseCase.Shared.ErrorsShared;

namespace UseCase.Product.Command.Handler
{
    public class CreateProductCommandHandler(IProductRepository _productRepository,
        IIventoryRepository _iventoryRepository,
        IMapper _mapper, IValidator<CreateProductCommand> _validator) : IRequestHandler<CreateProductCommand, Result>
    {
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var _product =await _productRepository.SelectAsync(request.ProductID);
            if (_product != null)  return Result.Failure(ErrorsShared.DuplicateKey);
            var result = await _validator.ValidateAsync(request);
            var _productAdd = _mapper.Map<Entities.Product>(request);
            if (!result.IsValid)
            {
                return Result.Failure(ErrorsShared.InvalidModel);
            }
            //Insert product
            await _productRepository.InsertAsync(_productAdd);
            // New Iventory
            var _iventory = new Iventory()
            {
                ID = Guid.NewGuid().ToString(),
                ProductID = request.ProductID,
                Qty = request.Qty,
            };
            //Insert Iventory
            await _iventoryRepository.InsertAsync(_iventory);
            return Result.Success;
        }
    }
}
