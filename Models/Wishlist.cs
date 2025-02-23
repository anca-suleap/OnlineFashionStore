using System.ComponentModel.DataAnnotations;

namespace OnlineFashionStore.Models
{
    public class Wishlist
    {
        public int ID { get; set; }

        
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        
        public int? ProductID { get; set; }
        public Product? Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
