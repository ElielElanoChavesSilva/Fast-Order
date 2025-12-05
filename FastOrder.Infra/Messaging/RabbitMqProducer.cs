using RabbitMQ.Client;
using System.Text;

namespace FastOrder.Infra.Messaging;

public class RabbitMqProducer
{
    private readonly RabbitMqConnection _connection;

    public RabbitMqProducer(RabbitMqConnection connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync(string queueName, string message)
    {
        await using var channel = await _connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            body: body
        );
    }
}
