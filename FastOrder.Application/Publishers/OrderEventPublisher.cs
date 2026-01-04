using FastOrder.Application.Events;
using FastOrder.Infra.Messaging;
using System.Text.Json;

namespace FastOrder.Application.Publishers;

public class OrderEventPublisher
{
    private readonly RabbitMqProducer _producer;
    private const string QueueName = "order-created-queue";

    public OrderEventPublisher(RabbitMqProducer producer)
    {
        _producer = producer;
    }

    public async Task PublishOrderCreatedAsync(OrderCreatedEvent orderEvent)
    {
        var json = JsonSerializer.Serialize(orderEvent);
        await _producer.PublishAsync(QueueName, json);
    }
}

