using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Interfaces.Respositories;
using UseCase.Product.UnitOfWork;
using UseCase.UnitOfWork.Order;

namespace Infrastructure.SQLServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSQLServerInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<SQLServerDbContext>
                (option =>
                option.UseSqlServer("Server=LAPTOP-FTH3N2IO;Database=OrderExample;User Id=sa;Password=123456;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;"));
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
            return services;
        }
    }
}
