namespace FastOrder.Infra.Messaging;

public class OrderCreatedEvent
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public decimal TotalPrice { get; set; }
}
