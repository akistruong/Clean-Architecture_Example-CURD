using MediatR;

namespace UseCase.Product.Command
{
    public class UpdateProductCommand : IRequest
    {
        public string ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? Qty { get; set; }
        public bool? IsStock { get; set; }
        public string? ProductDescription { get; set; }
    }
}
