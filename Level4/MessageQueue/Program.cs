// Install: dotnet add package RabbitMQ.Client

// Producer - sends messages
using System;
using RabbitMQ.Client;
using System.Text;

class Producer
{
    static void Main()
    {
        var factory    = new ConnectionFactory() { HostName = "localhost" };
        using var conn = factory.CreateConnection();
        using var ch   = conn.CreateModel();

        ch.QueueDeclare(queue:      "studentQueue",
                        durable:    false,
                        exclusive:  false,
                        autoDelete: false,
                        arguments:  null);

        Console.WriteLine("Producer ready. Type messages (type 'exit' to quit):");

        while (true)
        {
            string message = Console.ReadLine();
            if (message == "exit") break;

            byte[] body = Encoding.UTF8.GetBytes(message);
            ch.BasicPublish(exchange:   "",
                            routingKey: "studentQueue",
                            basicProperties: null,
                            body: body);

            Console.WriteLine($"[Sent] {message}");
        }
    }
}

