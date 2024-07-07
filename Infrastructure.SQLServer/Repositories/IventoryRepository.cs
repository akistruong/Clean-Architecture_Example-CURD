using Entities;
using Entities.Respositories;
using Infrastructure.SQLServer.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQLServer.Repositories
{
    public class IventoryRepository : RepositoryBase<Entities.Iventory>, IIventoryRepository
    {
        SQLServerDbContext _orderDbContext;
        public IventoryRepository(SQLServerDbContext orderDbContext) : base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
            Console.WriteLine("DbContext:IventoryRepository " + orderDbContext.GetHashCode().ToString());
        }

        public async Task<Iventory> GetIventoryByProductID(string productID)
        {
            var Iventory = await _orderDbContext.Iventories.FirstOrDefaultAsync(x => x.ProductID == productID);
            if (Iventory == null)
            {
                return null;
            }
            return Iventory;
        }
    }
}
