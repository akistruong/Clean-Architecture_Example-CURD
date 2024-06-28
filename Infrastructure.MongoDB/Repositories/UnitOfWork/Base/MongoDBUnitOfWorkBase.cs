using Infrastructure.MongoDB.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UnitOfWork.Base;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.MongoDB.Repositories.UnitOfWork.Base
{
    public class MongoDBUnitOfWorkBase : IUnitOfWorkBase
    {
        MongoDBService _mongoDB;
        IClientSessionHandle _session;
        public MongoDBUnitOfWorkBase(MongoDBService mongoDB)
        {
            _mongoDB = mongoDB;
            _session = mongoDB.Database.Client.StartSession();
        }
        public async Task Begin()
        {
            _session.StartTransaction();
            var tem = _session;
        }

        public async Task Cancel()
        {
            await _session.AbortTransactionAsync();
        }

        public async Task Commit()
        {
            await _session.CommitTransactionAsync(); 
        }
    }
}
