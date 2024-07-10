using Entities;
using UseCase.Interfaces.Respositories.Base;

namespace UseCase.Interfaces.Respositories
{
    public interface IIventoryRepository : IRepositoryBase<Iventory>
    {
        public Task<Iventory> GetIventoryByProductID(string productID);
    }
}
