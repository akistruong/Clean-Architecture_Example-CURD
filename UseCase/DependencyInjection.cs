using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Order.Commands.Handlers;
using UseCase.Product.Command.Handler;
using UseCase.Product.Query.Handler;
using UseCase.Validators;

namespace UseCase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                //VALIDATOR
               services.AddScoped<IValidator<Entities.Product>, ProductValidator>();
               services.AddScoped<IValidator<Entities.Order>, OrderValidator>();
               services.AddScoped<IValidator<Entities.OrderItem>, OrderItemValidator>();
                //PRODUCT
                cfg.RegisterServicesFromAssembly(typeof(PropductQueryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteProductCommandHandler).Assembly);
                //ORDER
                cfg.RegisterServicesFromAssembly(typeof(PlaceOrderCommandHandler).Assembly);
            });
            return services;
        }
    }
}
