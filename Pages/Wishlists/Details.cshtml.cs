using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFashionStore.Data;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Pages.Wishlists
{
    public class DetailsModel : PageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public DetailsModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        public Wishlist Wishlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.FirstOrDefaultAsync(m => m.ID == id);
            if (wishlist == null)
            {
                return NotFound();
            }
            else
            {
                Wishlist = wishlist;
            }
            return Page();
        }
    }
}
