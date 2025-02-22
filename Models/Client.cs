using System.ComponentModel.DataAnnotations;

namespace OnlineFashionStore.Models
{
    public class Client
    {
        public int ID { get; set; }
        
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }

        
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Wishlist>? Wishlists { get; set; }
    }
}
