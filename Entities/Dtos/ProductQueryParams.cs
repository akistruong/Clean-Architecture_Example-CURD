using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductQueryParams
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;
        public IEnumerable<string> Colors { get; set; }=  new List<string>();
        public int Limit { get; set; }
        public int Page { get; set; }


    }
}
