using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineFashionStore.Data;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Pages.Products
{
    public class EditModel : ProductSizesPageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public EditModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                  .Include(p => p.ProductSizes)
                      .ThenInclude(p => p.Size)
                  .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null) return NotFound();

            PopulateAssignedSizeData(_context, Product);
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSizes)
        {
            if (id == null) return NotFound();

            var itemToUpdate = await _context.Product
                .Include(p => p.ProductSizes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (itemToUpdate == null) return NotFound();

            if (await TryUpdateModelAsync<Product>(
                itemToUpdate, "Product",
                p => p.Name, p => p.Price, p => p.CategoryID))
            {
                UpdateProductSizes(_context, selectedSizes, itemToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedSizeData(_context, itemToUpdate);
            return Page();
        }


    }
}
