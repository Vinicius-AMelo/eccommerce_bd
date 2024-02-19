using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Context
{
    public class StudyContext : DbContext
    {
        public StudyContext(DbContextOptions<StudyContext> options) : base(options)
        {
        }

        public DbSet<Product> product { get; set; }
    }
}