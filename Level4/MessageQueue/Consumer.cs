// Consumer - receives messages (run in separate project)
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Consumer
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

        var consumer = new EventingBasicConsumer(ch);
        consumer.Received += (model, ea) =>
        {
            string message = Encoding.UTF8.GetString(ea.Body.ToArray());
            Console.WriteLine($"[Received] {message}");
        };

        ch.BasicConsume(queue:     "studentQueue",
                        autoAck:   true,
                        consumer:  consumer);

        Console.WriteLine("Consumer waiting for messages. Press ENTER to exit.");
        Console.ReadLine();
    }
}