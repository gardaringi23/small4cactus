using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Receive
{
    public static void Main()
    {
        var factory = new ConnectionFactory() {HostName = "localhost:3000"};
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            //channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
            channel.QueueDeclare(queue: "hello",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            

            //var queueName = channel.QueueDeclare().QueueName;
            //channel.QueueBind(queue: queueName,
                           // exchange: "logs",
                           // routingKey: "");

            //Console.WriteLine("[*] Waiting for logs.");

            var consumer = new EventBasicConsumer(channel);
            consumer.Received += (model, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x]  {0} ", message);
            };
            channel.BasicConsumer(queue: queueName,
                                autoAck: true,
                                consumer: consumer);

            Console.WriteLine("Press [enter] to exit");
            Console.WriteLine();
        }
    }
}