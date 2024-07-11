using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UseCase.Behaviors;
using UseCase.Order.Commands;
using UseCase.Order.Commands.Handlers;
using UseCase.Order.Validators;
using UseCase.OrderItem;
using UseCase.OrderItem.Validators;
using UseCase.Product.Command;
using UseCase.Product.Command.Handler;
using UseCase.Product.Query.Handler;
using UseCase.Product.Validators;

namespace UseCase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                //VALIDATOR
                services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
                services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();
                services.AddScoped<IValidator<PlaceOrderCommand>, PlaceOrderCommandValidator>();
                services.AddScoped<IValidator<OrderItemCommand>, OrderItemValidator>();
                //PRODUCT
                cfg.RegisterServicesFromAssembly(typeof(PropductQueryCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteProductCommandHandler).Assembly);
                cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
                //ORDER
                cfg.RegisterServicesFromAssembly(typeof(PlaceOrderCommandHandler).Assembly);

            });
            services.AddAutoMapper(Assembly.Load("UseCase"));
            return services;
        }
    }
}
