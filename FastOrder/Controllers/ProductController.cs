using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    [Route("products")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<CreatedResult> PostAsync(ProductDTO product)
        {
            var id = await _productService.PostAsync(product);
            return Created("products", id);
        }
    }
}
