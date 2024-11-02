// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");


var factoty = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/",

};
var conn = await factoty.CreateConnectionAsync();
using var channel = await conn.CreateChannelAsync();

await channel.QueueDeclareAsync("bookings", durable: true, exclusive: false, autoDelete: false);

//var consumer = new AsyncEventingBasicConsumer(channel);

// Set up the consumer
var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"New Ticket processing message: {message}");

    // Simulate processing time or handle the message further here
    await Task.Yield(); // Placeholder for any async processing
};

// Start consuming messages from the queue
await channel.BasicConsumeAsync(queue: "bookings", autoAck: true, consumer: consumer);

Console.ReadKey();