namespace OnlineFashionStore.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<ProductSize> ProductSizes { get; set; }

    }
}
