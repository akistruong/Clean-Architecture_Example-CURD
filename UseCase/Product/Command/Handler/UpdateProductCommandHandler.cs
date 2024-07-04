using AutoMapper;
using Entities.Respositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private IMapper _mapper;
        private IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Entities.Product>(request);
                _productRepository.Update(product);
                await _productRepository.SaveChangesAsync();
            }catch (Exception ex) {
                throw ex;
            }
        }
    }
}
