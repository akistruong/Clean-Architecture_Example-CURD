using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public string ProductID { get; set; }   
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; } = 0;
        public bool IsStock { get; set; } = true;
        public string? ProductDescription { get; set; }
        public List<OrderItem>? OrderItems { get; set; } 
        public bool isLowQty()
        {
            return this.Qty < 5 ? true : false;
        }
        public List<Iventory> ?Iventories { get; set; } 
    }
}
