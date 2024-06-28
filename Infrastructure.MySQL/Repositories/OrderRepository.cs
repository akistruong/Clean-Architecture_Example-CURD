using Entities;
using Entities.Respositories;
using Infrastructure.MySQL.Repositories.Base;

namespace Infrastructure.MySQL.Repositories
{
    public class OrderRepository : RepositoryBase<Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
