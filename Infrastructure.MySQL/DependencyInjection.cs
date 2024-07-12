using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Interfaces.Data;
using UseCase.Interfaces.Respositories;

namespace Infrastructure.MySQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMySQLInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<IDbContext, OrderDbContext>(option =>
            {
                option.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=ordermodule;Allow User Variables=True");
            });
            /*PRODUCT*/
            services.AddTransient<IProductRepository, Repositories.ProductRepository>();

            /* ORDER*/
            services.AddTransient<IOrderRepository, Repositories.OrderRepository>();
            /*IVENTORY*/
            services.AddTransient<IIventoryRepository, Repositories.IventoryRepository>();
            /*PAGINATION*/
            //builder.Services.AddTransient<IProductPagination, ProductPagination>();
            //UnitOfWork
            return services;
        }
    }
}
