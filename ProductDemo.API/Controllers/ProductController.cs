using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Abstraction.Interfaces;
using ProductDemo.Domain.Dto;

namespace ProductDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            await _productService.AddProductAsync(product);
            return Ok();
        }
    }
}
