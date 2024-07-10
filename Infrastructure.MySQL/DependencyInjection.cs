using Infrastructure.MySQL.UnitOfWork.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Interfaces.Respositories;
using UseCase.Interfaces.UnitOfWork.Product;
using UseCase.Product.UnitOfWork;
using UseCase.UnitOfWork.Order;

namespace Infrastructure.MySQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMySQLInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(option =>
            {
                option.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=ordermodule;Allow User Variables=True");
            });
            /*PRODUCT*/
            services.AddTransient<IProductRepository, Repositories.ProductRepository>();
            services.AddTransient<ICreateProductUnitOfWork, CreateProductUnitOfWork>();
            services.AddTransient<IUpdateProductUnitOfWork, UpdateProductUnitOfWork>();
            /* ORDER*/
            services.AddTransient<IOrderRepository, Repositories.OrderRepository>();
            services.AddTransient<ICreateOrderUnitOfWork, UnitOfWork.Order.CreateOrderUnitOfWork>();
            /*IVENTORY*/
            services.AddTransient<IIventoryRepository, Repositories.IventoryRepository>();
            /*PAGINATION*/
            //builder.Services.AddTransient<IProductPagination, ProductPagination>();
            //UnitOfWork
            return services;
        }
    }
}
