using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Shared
{
    public class Error
    {
        public string _message { get; set; }
        public Error(string message)
        {
            _message = message;
        }
        public static Error None => null!;
    }
}
