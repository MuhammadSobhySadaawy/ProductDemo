using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Dto;
using ProductDemo.Domain.Entities;

namespace ProductDemo.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task AddAsync(ProductDto product);
        Task<Product?> GetByIdAsync(int id);
    }
}
