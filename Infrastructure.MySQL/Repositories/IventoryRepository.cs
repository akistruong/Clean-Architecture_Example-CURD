using Entities;
using Entities.Respositories;
using Infrastructure.MySQL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MySQL.Repositories
{
    public class IventoryRepository : RepositoryBase<Entities.Iventory>, IIventoryRepository
    {
        OrderDbContext _orderDbContext; 
        public IventoryRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
            Console.WriteLine("DbContext:IventoryRepository " + orderDbContext.GetHashCode().ToString() );
        }

        public async Task<Iventory> GetIventoryByProductID(string productID)
        {
            var Iventory = await _orderDbContext.Iventories.FirstOrDefaultAsync(x => x.ProductID == productID);
            if(Iventory == null) {
                return null;
            }
            return Iventory;
        }
    }
}
