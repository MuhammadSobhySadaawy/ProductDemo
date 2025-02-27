using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain;
using ProductDemo.Domain.Dto;
using ProductDemo.Domain.Repositories;

namespace ProductDemo.Services.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork  unitOfWork)
        {
          
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await _unitOfWork.productRepository.GetAllAsync();
        }

        public async Task AddProductAsync(ProductDto product)
        {
              await _unitOfWork.productRepository.AddAsync(product);
        }
    }
}
