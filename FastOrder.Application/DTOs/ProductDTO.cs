namespace FastOrder.Application.DTOs
{
    public record ProductDTO(
        long Id,
        string Name,
        string CategoryName,
        long CategoryId);
}
