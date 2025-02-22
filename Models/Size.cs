using System.Collections.Generic;

namespace OnlineFashionStore.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}