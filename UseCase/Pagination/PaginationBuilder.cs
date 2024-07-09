using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Pagination.Base;

namespace UseCase.Pagination
{
    public class PaginationBuilder<T> : IPagination<T> where T : class
    {
        private int _limit;
        private int _page;
        private IEnumerable<T> _source;
        public IEnumerable<T> Build()
        {
            int _skip = _page - 1;
            _source = _source.Skip(_skip).Take(_limit);
            return _source;
        }

        public IEnumerable<T> Excute(IEnumerable<T> _source, int _limit, int _page)
        {
            throw new NotImplementedException();
        }

        public IPagination<T> Limit(int limit)
        {
            _limit = limit > 0 ? limit : 2  ;
            return this;
        }

        public IPagination<T> Page(int page)
        {
            _page = page>0?page:1;
            return this;
        }

        public IPagination<T> Source(IEnumerable<T> source)
        {
           this._source = source;
            return this;
        }
    }
}
