using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Pagination.Base
{
    public interface IPagination<T>
    {
        
        public IEnumerable<T> Excute(IEnumerable<T> _source,int _limit, int _page);
    }
}
