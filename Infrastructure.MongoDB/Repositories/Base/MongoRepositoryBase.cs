using Entities.Respositories.Base;
using Infrastructure.MongoDB.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.MongoDB.Repositories.Base
{
    public class MongoRepositoryBase<T> : IRepositoryBase<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepositoryBase(MongoDBService _mongoDB)
        {
            var collectionName = typeof(T).Name;
            _collection = _mongoDB.Database.GetCollection<T>(collectionName);
        }

        public async void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task SaveChanges(T entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync(string ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> SelectAsync()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();    
        }

        public  T Update(T entity)
        {

            throw new NotImplementedException();


        }
    }
}
