using AutoMapper;
using Entities;
using FluentValidation;
using MediatR;
using UseCase.Product.UnitOfWork;
using UseCase.Shared;

namespace UseCase.Product.Command.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Result>
    {
        private ICreateProductUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(ICreateProductUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _unitOfWork.Begin();
                var result = await _validator.ValidateAsync(request);
                var _productAdd = _mapper.Map<Entities.Product>(request);
                if (!result.IsValid)
                {
                    return Result.Failure(new Error("Validation excception"));

                }
                //Insert product
                await _unitOfWork._productRepository.InsertAsync(_productAdd);
                // New Iventory
                var _iventory = new Iventory()
                {
                    ID = Guid.NewGuid().ToString(),
                    ProductID = request.ProductID,
                    Qty = request.Qty,
                };
                //Insert Iventory
                await _unitOfWork._iventoryRepository.InsertAsync(_iventory);
                await _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
