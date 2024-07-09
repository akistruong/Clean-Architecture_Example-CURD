using Entities;
using InterfaceAdapter.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapter.Order
{
    public class OrderInsertRequest
    {
        public decimal TotalOrder { get; set; }
        public decimal TotalQty { get; set; }
        public string? EmailOrder { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }
}
