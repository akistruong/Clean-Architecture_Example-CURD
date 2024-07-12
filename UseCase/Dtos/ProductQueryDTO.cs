using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Dtos
{
    public class ProductQueryDTO
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;
    }
}
