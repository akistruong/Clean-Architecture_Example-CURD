using Microsoft.EntityFrameworkCore;
using UseCase.Interfaces.Respositories.Base;

namespace Infrastructure.SQLServer.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private SQLServerDbContext OrderDbContext;

        public RepositoryBase(SQLServerDbContext orderDbContext)
        {
            OrderDbContext = orderDbContext;
        }

        public void Delete(T entity)
        {
            OrderDbContext.Remove(entity);
        }

        public virtual async Task InsertAsync(T entity)
        {
            await OrderDbContext.Set<T>().AddAsync(entity);
        }

        public virtual Task SaveChanges(T entity) => OrderDbContext.SaveChangesAsync();

        public async Task SaveChangesAsync()
        {
            await OrderDbContext.SaveChangesAsync();
        }



        public virtual List<T> Select()
        {
            return OrderDbContext.Set<T>().ToList();
        }

        public virtual async Task<T> SelectAsync(string ID)
        {
            var result = await OrderDbContext.Set<T>().FindAsync(ID);
            if (result is not null)
            {
                return result;
            }
            return null;
        }

        public virtual async Task<IReadOnlyList<T>> SelectAsync()
        {
            var result = await OrderDbContext.Set<T>().ToListAsync();
            return result;
        }

        public virtual T Update(T entity)
        {
            OrderDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return entity;
        }


    }
}
