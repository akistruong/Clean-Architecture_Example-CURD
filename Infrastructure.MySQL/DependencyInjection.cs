using Entities.Respositories;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<OrderDbContext>(option =>
            {
                option.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=ordermodule;Allow User Variables=True");
            });
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
