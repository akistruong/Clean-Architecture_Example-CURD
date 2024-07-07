namespace InterfaceAdapter.Product
{
    public class ProductUpdateRequest
    {
        public string ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? Qty { get; set; }
        public bool? IsStock { get; set; }
        public string? ProductDescription { get; set; }
    }
}
