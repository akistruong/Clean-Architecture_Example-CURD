using Infrastructure.MySQL.Repositories.Base;
using UseCase.Interfaces.Respositories;

namespace Infrastructure.MySQL.Repositories
{
    internal class OrderRepository : RepositoryBase<Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
