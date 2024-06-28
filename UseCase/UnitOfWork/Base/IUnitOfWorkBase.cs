using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.UnitOfWork.Base
{
    public interface IUnitOfWorkBase
    {
        public Task Begin();
        public Task Commit();
        public Task Cancel();
    }
}
