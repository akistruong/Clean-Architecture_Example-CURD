using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Interfaces.Data;
using UseCase.Interfaces.Respositories;

namespace Infrastructure.SQLServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSQLServerInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<IDbContext, SQLServerDbContext>
                (option =>
                option.UseSqlServer("Server=LAPTOP-FTH3N2IO;Database=OrderExample;User Id=sa;Password=123456;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;"));
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
