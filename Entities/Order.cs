using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public string OrderID { get; set; } 
        public decimal TotalOrder { get; set; }
        public decimal TotalQty { get; set; }

        public List<OrderItem> Items { get; set; }  

        public decimal GetTotalPrice()
        {
           return this.Items.Sum(x=>x.Price);
        }
        public int GetTotalQty() { 
            return this.Items.Sum(x=>x.Qty);    
        }
    }
}
