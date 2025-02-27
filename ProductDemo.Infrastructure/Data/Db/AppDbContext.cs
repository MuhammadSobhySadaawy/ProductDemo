
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Aggregates;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Infrastructure.Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
      .OwnsOne(c => c.Address, a =>
      {
          a.Property(p => p.Street).HasColumnName("Street");
          a.Property(p => p.City).HasColumnName("City");
          a.Property(p => p.ZipCode).HasColumnName("ZipCode");
      });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
    //public class EAGPServeBigDbContext : IdentityDbContext<AspNetUser>
    //{
    //    public EAGPServeBigDbContext(DbContextOptions<EAGPServeBigDbContext> options) : base(options) { }

    //    public DbSet<AspNetUser> AspNetUsers { get; set; }
    //}
    //public class MOTA1umbracoDbContext : DbContext
    //{
    //    public MOTA1umbracoDbContext(DbContextOptions<MOTA1umbracoDbContext> options) : base(options) { }
    //    public DbSet<CmsMember> cmsMember { get; set; }


    //}
}
