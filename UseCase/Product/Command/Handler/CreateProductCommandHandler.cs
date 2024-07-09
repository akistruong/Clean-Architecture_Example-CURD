using AutoMapper;
using Entities;
using FluentValidation;
using MediatR;
using UseCase.Product.UnitOfWork;

namespace UseCase.Product.Command.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private ICreateProductUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IValidator<Entities.Product> _validator;
        public CreateProductCommandHandler(ICreateProductUnitOfWork unitOfWork, IMapper mapper, IValidator<Entities.Product> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _unitOfWork.Begin();
                var _productAdd = _mapper.Map<Entities.Product>(request.request);
                var result = await _validator.ValidateAsync(_productAdd);

                if (!result.IsValid)
                {
                    throw new Exception();
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
