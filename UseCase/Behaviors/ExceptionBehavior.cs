using MediatR;
using Microsoft.Extensions.Logging;
using UseCase.Shared;

namespace UseCase.Behaviors
{
    internal class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var response = await next();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(
             "Request failure {@RequestName}, {@Error}, {@DateTimeUtc}",
             typeof(TRequest).Name, ex.Message,
             DateTime.UtcNow);
                throw ex;
            }
        }
    }
}
