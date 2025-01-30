using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain.Dto;
using ProductDemo.Domain.Repositories;

namespace ProductDemo.Services.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task AddProductAsync(ProductDto product)
        {
            return _repository.AddAsync(product);
        }
    }
}
