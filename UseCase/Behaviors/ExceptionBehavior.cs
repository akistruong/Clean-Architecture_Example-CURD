using MediatR;
using Microsoft.Extensions.Logging;
using UseCase.Shared;

namespace UseCase.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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

                _logger.LogInformation(
          "Starting request {@RequestName}, {@DateTimeUtc}",
          typeof(TRequest).Name,
          DateTime.UtcNow);
                var response = await next();
                _logger.LogInformation(
         "Completed request {@RequestName}, {@DateTimeUtc}",
         typeof(TRequest).Name,
         DateTime.UtcNow);
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
