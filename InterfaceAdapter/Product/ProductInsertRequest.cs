namespace InterfaceAdapter.Product
{
    public class ProductInsertRequest
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
        public bool IsStock { get; set; } = true;
        public string? ProductDescription { get; set; }
    }
}
