using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
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


