using RabbitMQ.Client;

namespace FastOrder.Infra.Messaging
{
    public class RabbitMqConnection : IAsyncDisposable
    {
        private readonly IConnection _connection;

        public RabbitMqConnection(string hostName, string userName, string password)
        {
            var factory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };

            _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
        }

        public async Task<IChannel> CreateChannelAsync()
        {
            return await _connection.CreateChannelAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _connection.CloseAsync();
            _connection.Dispose();
        }
    }
}
