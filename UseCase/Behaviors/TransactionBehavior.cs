using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interfaces.Data;

namespace UseCase.Behaviors
{
    internal class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IDbContext _dbContext;

        public TransactionBehavior(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                 
                var response = await next();
                await _dbContext.SaveChangesAsync();
                return response;
            }catch (Exception ex) {
               
                throw ex;   
            }
        }
    }
}
