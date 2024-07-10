using UseCase.Interfaces.UnitOfWork.Base;

namespace Infrastructure.MySQL.UnitOfWork.Base
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        OrderDbContext _orderDbContext;

        public UnitOfWorkBase(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            Console.WriteLine("DbContext:UnitOfWorkBase" + orderDbContext.GetHashCode().ToString());
        }

        public async Task Begin()
        {
            await _orderDbContext.Database.BeginTransactionAsync();
        }

        public async Task Cancel()
        {
            await _orderDbContext.Database.RollbackTransactionAsync();

        }

        public async Task Commit()
        {
            await _orderDbContext.SaveChangesAsync();
            await _orderDbContext.Database.CommitTransactionAsync();
        }
    }
}
