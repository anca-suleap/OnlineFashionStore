using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineFashionStore.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
