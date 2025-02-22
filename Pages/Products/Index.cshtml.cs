using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineFashionStore.Data;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly OnlineFashionStore.Data.OnlineFashionStoreContext _context;

        public IndexModel(OnlineFashionStore.Data.OnlineFashionStoreContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? sizeID, string? searchString, int? categoryId)
        {

            ProductD = new ProductData();
            CurrentFilter = searchString;


            ViewData["Categories"] = await _context.Category.ToListAsync();


            var items = _context.Product
                .Include(c => c.Category)
                .Include(c => c.ProductSizes)
                .ThenInclude(cs => cs.Size)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(p => p.Name.Contains(searchString) || p.Category.CategoryName.Contains(searchString));
            }


            if (categoryId.HasValue)
            {
                items = items.Where(p => p.CategoryID == categoryId);
            }


            ProductD.Products = await items.ToListAsync() ?? new List<Product>();
        }
    }
}
