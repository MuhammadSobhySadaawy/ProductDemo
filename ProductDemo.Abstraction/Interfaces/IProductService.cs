using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Domain.Dto;

namespace ProductDemo.Abstraction.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task AddProductAsync(ProductDto product);
    }
}
