using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Shared
{
    public class ResultT<T> : Result
    {
        public T _value { get; }
        public ResultT(bool isSuccessed, Error error, T value) : base(isSuccessed, error)
        {
            _value = value;
        }
        public static ResultT<T> Success(T value) => new(true, Error.None, value);
        public static ResultT<T> Failure(T value, Error error) => new(false, error, value);
        public static ResultT<T> NotFound(T value, Error error) => new(false, error, value);

    }
}
