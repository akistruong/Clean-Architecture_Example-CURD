using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.OrderItem
{
    public record class OrderItemCommand(string ProductID, int Qty,decimal Price);
}
