using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
    }
}