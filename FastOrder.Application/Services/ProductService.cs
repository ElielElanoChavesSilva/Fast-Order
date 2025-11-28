using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using FastOrder.Application.Mappers;
using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Repositories.Category;

namespace FastOrder.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var entities = await _productRepository.FindAll();
            return ProductMapper.ToListDTO(entities);
        }

        public async Task<long> PostAsync(ProductDTO product)
        {
            var category = await _categoryRepository.FindById(product.CategoryId);
            if (category == null)
                throw new Exception("");

            var entity = await _productRepository.Add(new()
            {
                Name = product.Name,
                Category = category
            });

            return entity.Id;
        }
    }
}
