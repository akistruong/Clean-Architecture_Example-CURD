using Entities.Respositories;
using Infrastructure.SQLServer.Repositories.Base;

namespace Infrastructure.SQLServer.Repositories
{
    public class OrderRepository : RepositoryBase<Entities.Order>, IOrderRepository
    {
        public OrderRepository(SQLServerDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
