using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Dtos
{
    public class OrderItemRequest
    {
        public string ProductID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderRequest
    {
        public decimal TotalOrder { get; set; }
        public decimal TotalQty { get; set; }
        public string? EmailOrder { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }
}
