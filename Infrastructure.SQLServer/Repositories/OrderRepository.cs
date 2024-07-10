using Infrastructure.SQLServer.Repositories.Base;
using UseCase.Interfaces.Respositories;

namespace Infrastructure.SQLServer.Repositories
{
    public class OrderRepository : RepositoryBase<Entities.Order>, IOrderRepository
    {
        public OrderRepository(SQLServerDbContext orderDbContext) : base(orderDbContext)
        {
        }
    }
}
