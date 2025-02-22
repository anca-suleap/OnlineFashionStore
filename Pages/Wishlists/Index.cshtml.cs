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
    public class IndexModel : PageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public IndexModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        public IList<Wishlist> Wishlist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Wishlist = await _context.Wishlist
                .Include(w => w.Client)
                .Include(w => w.Product).ToListAsync();
        }
    }
}
