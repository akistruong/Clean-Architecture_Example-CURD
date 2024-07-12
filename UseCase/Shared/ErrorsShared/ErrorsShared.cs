using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Shared.ErrorsShared
{
    public class ErrorsShared : Error
    {
        public ErrorsShared(string message) : base(message)
        {
        }
        public static Error InvalidModel => new("Error.InvalidModel");
        public static Error DuplicateKey => new("Error.DuplicateKey");
    }
}
