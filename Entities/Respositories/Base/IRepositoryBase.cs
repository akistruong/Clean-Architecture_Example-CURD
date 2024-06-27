using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Respositories.Base
{
    public interface IRepositoryBase<T>
    {
        public T Select(T ID);
        public List<T> Select();
        public T Insert(T order);
        public T Update(T order);
        public bool Delete(T order);
    }
}
