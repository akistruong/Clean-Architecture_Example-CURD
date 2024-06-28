using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Pagination.Base;

namespace Infrastructure.MySQL.Repositories.Pagination
{
    public class Pagination<T> : IPagination<T>
    {
        public IEnumerable<T> Excute(IEnumerable<T> _source, int _limit, int _page)
        {   
           
            int _skip =_page - 1; 
           _source = _source.Skip(_skip).Take(_limit);
            return _source;
        }
    }
}
