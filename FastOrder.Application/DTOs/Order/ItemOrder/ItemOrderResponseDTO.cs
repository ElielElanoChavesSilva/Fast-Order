namespace FastOrder.Application.DTOs.Order.ItemOrder
{
    public class ItemOrderResponseDTO
    {
        public int QtdProduct { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
