using ConsumerAPI.Conection;
using RabbitMQ.Client.Events;
using System.Text;

namespace ConsumerAPI
{
    public class OrderCreatedConsumer
    {
        private readonly RabbitMqConnection _connection;
        private const string QueueName = "order-created-queue";

        public OrderCreatedConsumer(RabbitMqConnection connection)
        {
            _connection = connection;
        }

        public async Task StartAsync()
        {
            var channel = await _connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            // Receiver
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                Console.WriteLine("📩 Mensagem recebida:");
                Console.WriteLine(json);

                // Aqui você pode desserializar e trabalhar com a mensagem:
                // var order = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                // Confirma o recebimento (ack)
                await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
            };

            // Começa a consumir
            await channel.BasicConsumeAsync(
                queue: QueueName,
                autoAck: false,
                consumer: consumer
            );

            Console.WriteLine("👂 Consumidor iniciado — aguardando mensagens...");
        }
    }

}
