using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Shared
{
    public class ValidationResult<T> : Result
    {
        public IEnumerable<T> Errors { get; set; }

        public ValidationResult(IEnumerable<T> errors):base(false,new Error("Error.ValidationError"))
        {
            Errors = errors;
        }
        public static ValidationResult<T> WithErrors(IEnumerable<T>errors) => new(errors);
    }
}
