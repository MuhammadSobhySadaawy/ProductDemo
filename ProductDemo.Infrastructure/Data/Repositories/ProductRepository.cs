using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Dto;
using ProductDemo.Domain.Entities;
using ProductDemo.Domain.Repositories;
using ProductDemo.Infrastructure.Data.Db;

namespace ProductDemo.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products.Where(e=>e.IsActive&& !e.IsDeleted)
                .Select(e=>new ProductDto { Id=e.Id,Name=e.Name,Price=e.Price})
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(ProductDto product)
        {
            await _context.Products.AddAsync(new Product 
            {
                Name= product.Name,
                Price = product.Price ,
                CreateUser=1,
                CreateDate=DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto product)
        {
            _context.Products.Update(new Product
            {
                Id=product.Id ,
                Name = product.Name,
                Price = product.Price, 
                LastUpdateUser = 1, 
                LastUpdateDate = DateTime.UtcNow 
            });
            await _context.SaveChangesAsync();
        }

       
    }
}