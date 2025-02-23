using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFashionStore.Data;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Pages.Wishlists
{
    public class CreateModel : PageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public CreateModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var productList = _context.Product
                .Select(x => new
       {
           x.Id,
           ProductDisplay = x.Name
       });
            ViewData["ProductID"] = new SelectList(productList, "Id", "ProductDisplay");

            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Wishlist Wishlist { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Wishlist.Add(Wishlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
