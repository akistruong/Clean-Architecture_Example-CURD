using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Commands.Product
{
    public class CreateProductCommand:IRequest
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; } = 0;
        public bool IsStock { get; set; } = true;
        public string? ProductDescription { get; set; }
    }
}
