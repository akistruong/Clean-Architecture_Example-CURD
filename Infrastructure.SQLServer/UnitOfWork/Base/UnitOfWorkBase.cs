using UseCase.Interfaces.UnitOfWork.Base;

namespace Infrastructure.SQLServer.UnitOfWork.Base
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        SQLServerDbContext _orderDbContext;

        public UnitOfWorkBase(SQLServerDbContext orderDbContext)
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
