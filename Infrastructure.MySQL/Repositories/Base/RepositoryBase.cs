using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Respositories.Base;

namespace Infrastructure.MySQL.Repositories.Base
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private OrderDbContext OrderDbContext;

        public RepositoryBase(OrderDbContext orderDbContext)
        {
            OrderDbContext = orderDbContext;
        }

        public bool Delete(T order)
        {
            OrderDbContext.Set<T>().Remove(order);
            return true;
        }

        public T Insert(T order)
        {
            OrderDbContext.Set<T>().Add
                (order);
            return order;
        }

        public T Select(T ID)
        {
            return OrderDbContext.Set<T>().Find(ID);

        }

        public List<T> Select()
        {
            return OrderDbContext.Set<T>().ToList();
        }

        public T Update(T order)
        {
            OrderDbContext.Entry(order).State = EntityState.Modified;   
            return order;
        }
    }
}
