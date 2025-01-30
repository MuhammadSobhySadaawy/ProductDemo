
using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Infrastructure.Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
