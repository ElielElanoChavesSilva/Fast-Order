namespace FastOrder.Application.DTOs.Order
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public decimal TotalPrice { get; set; }
        public long IdClient { get; set; }
    }
}
