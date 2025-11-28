using FastOrder.Application.DTOs;

namespace FastOrder.Application.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<long> PostAsync(ProductDTO product);
    }
}
