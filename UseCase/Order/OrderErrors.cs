using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Shared;

namespace UseCase.Order
{
    internal class OrderErrors : Error
    {
        public OrderErrors(string message) : base(message)
        {
        }
        public static Error QtyInvalid=>new("Error.QtyInvalid");
    }
}
