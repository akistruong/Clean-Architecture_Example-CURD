using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Respositories.Base;

namespace Entities.Respositories
{
    public interface IIventoryRepository:IRepositoryBase<Iventory>
    {
        public Task<Iventory> GetIventoryByProductID (string productID);
    }
}
