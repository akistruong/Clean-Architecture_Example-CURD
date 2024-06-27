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
        public string ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public List<OrderItem> OrderItems { get; set; }  
    }
}
