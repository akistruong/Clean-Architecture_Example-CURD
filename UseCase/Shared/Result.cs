using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Shared
{
    public class Result
    {
        public bool _isSuccessed { get; set; }
        public Error _error { get; set; }
        public Result(bool isSuccessed, Error error)
        {
            _isSuccessed = isSuccessed;
            _error = error;
        }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) =>new(false, error);
    }
}
