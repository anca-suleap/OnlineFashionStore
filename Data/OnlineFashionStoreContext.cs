using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineFashionStore.Models;

namespace OnlineFashionStore.Data
{
    public class OnlineFashionStoreContext : DbContext
    {
        public OnlineFashionStoreContext (DbContextOptions<OnlineFashionStoreContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineFashionStore.Models.Product> Product { get; set; } = default!;
        public DbSet<OnlineFashionStore.Models.Category> Category { get; set; } = default!;
        public DbSet<OnlineFashionStore.Models.Size> Size { get; set; } = default!;
        public DbSet<OnlineFashionStore.Models.Client> Client { get; set; } = default!;
        public DbSet<OnlineFashionStore.Models.Wishlist> Wishlist { get; set; } = default!;
    }
}
