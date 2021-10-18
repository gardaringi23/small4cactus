using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost:3000"};
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            string message = "Hello World";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                routingKey: "hello",
                                basicProperties: null,
                                body: body);
            Console.WriteLine(" [x] sent {0}", message);
        }

        Console.WriteLine("press [Enter] to exit");
        Console.ReadLine();
    }
}