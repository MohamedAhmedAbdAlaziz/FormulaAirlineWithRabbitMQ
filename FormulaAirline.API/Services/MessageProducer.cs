using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FormulaAirline.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public async Task SendingMessage<T>(T message)
        {
            var factoty = new ConnectionFactory()
            {
                HostName="localhost",
                UserName="user",
                Password="mypass",
                VirtualHost ="/",

            };
            var conn = await  factoty.CreateConnectionAsync();

            using var channel = await conn.CreateChannelAsync();

            await channel.QueueDeclareAsync("bookings", durable: true, exclusive: false, autoDelete: false);

            // Publish a message
          var jonString= JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jonString);
            await channel.BasicPublishAsync(exchange: "", routingKey: "bookings", mandatory: false, body);

        }
    }
}
