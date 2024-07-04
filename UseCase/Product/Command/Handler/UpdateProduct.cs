using AutoMapper;
using Entities.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Dtos;
using UseCase.Product.Command;

namespace UseCase.Product.Command.Handler
{
    public class UpdateProduct : IUpdateProduct
    {
        IProductRepository _repository;
        IMapper _mapper;
        public UpdateProduct(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Update(ProductRequest request)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request);

                var _product = _mapper.Map<Entities.Product>(request);
                _repository.Update(_product);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
