using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineFashionStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
        [Display(Name = "Product")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]

        public int? CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductSize>? ProductSizes { get; set; }
        public ICollection<Wishlist>? Wishlists { get; set; }

    }
}