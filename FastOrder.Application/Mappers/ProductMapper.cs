using FastOrder.Application.DTOs;
using FastOrder.Domain.Entities;

namespace FastOrder.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(ProductEntity product)
        {
            return new(product.Id, product.Name, product.Category.Name, product.Category.Id);
        }

        public static IEnumerable<ProductDTO> ToListDTO(IEnumerable<ProductEntity> products)
        {
            return products.Select(x => new ProductDTO(x.Id, x.Name, x.Category.Name, x.Category.Id));
        }
    }
}
