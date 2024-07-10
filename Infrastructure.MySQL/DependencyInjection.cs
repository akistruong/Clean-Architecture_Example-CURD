using Entities.Respositories;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Product.UnitOfWork;
using UseCase.UnitOfWork.Base;
using UseCase.UnitOfWork.Order;

namespace Infrastructure.MySQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMySQLInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>();
            /*PRODUCT*/
            services.AddTransient<IProductRepository, Repositories.ProductRepository>();
            services.AddTransient<ICreateProductUnitOfWork, UnitOfWork.Product.CreateProductUnitOfWork>();
            /* ORDER*/
            services.AddTransient<IOrderRepository, Repositories.OrderRepository>();
            services.AddTransient<ICreateOrderUnitOfWork, UnitOfWork.Order.CreateOrderUnitOfWork>();
            /*IVENTORY*/
            services.AddTransient<IIventoryRepository, Repositories.IventoryRepository>();
            /*PAGINATION*/
            //builder.Services.AddTransient<IProductPagination, ProductPagination>();
            //UnitOfWork
            services.AddTransient<IUnitOfWorkBase, UnitOfWork.Base.UnitOfWorkBase>();
            return services;
        }
    }
}
