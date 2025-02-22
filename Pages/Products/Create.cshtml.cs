using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineFashionStore.Data;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Pages.Products
{
    public class CreateModel : ProductSizesPageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public CreateModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");

            var product = new Product();
            product.ProductSizes = new List<ProductSize>();

            PopulateAssignedSizeData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedSizes)
        {
            var newProduct = new Product();
            if (selectedSizes != null)
            {
                newProduct.ProductSizes = new List<ProductSize>();
                foreach (var size in selectedSizes)
                {
                    var sizeToAdd = new ProductSize { SizeID = int.Parse(size) };
                    newProduct.ProductSizes.Add(sizeToAdd);
                }
            }

            Product.ProductSizes = newProduct.ProductSizes;
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
