using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Base;

namespace Infrastructure.MySQL.UnitOfWork.Base
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        OrderDbContext _orderDbContext;

        public UnitOfWorkBase(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            Console.WriteLine("DbContext:ProductRepository" + orderDbContext.GetHashCode().ToString());
        }

        public async Task Begin()
        {
            await _orderDbContext.Database.BeginTransactionAsync();    
        }

        public async Task Cancel()
        {
            await _orderDbContext.DisposeAsync();   
        }

        public async Task Commit()
        {
            await _orderDbContext.SaveChangesAsync();
            await _orderDbContext.Database.CommitTransactionAsync();
        }
    }
}
