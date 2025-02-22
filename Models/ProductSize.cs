﻿namespace OnlineFashionStore.Models
{
    public class ProductSize
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int SizeID { get; set; }
        public Size Size { get; set; }
    }
}
