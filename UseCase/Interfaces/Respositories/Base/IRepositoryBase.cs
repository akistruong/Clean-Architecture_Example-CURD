using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Interfaces.Respositories.Base
{
    public interface IRepositoryBase<T>
    {

        public Task<T> SelectAsync(string ID);
        public Task<IReadOnlyList<T>> SelectAsync();
        public Task SaveChanges(T entity);
        public Task SaveChangesAsync();

        public T Update(T entity);
        public void Delete(T entity);
        public Task InsertAsync(T entity);



    }
}
