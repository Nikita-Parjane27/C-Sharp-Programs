using System;
namespace EventsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Publisher class
            Publisher publisher = new Publisher();

            // Subscribe to the event using a lambda expression
            publisher.OnEventOccurred += (sender, e) =>
            {
                Console.WriteLine("Event occurred! Message: " + e.Message);
            };

            // Trigger the event
            publisher.TriggerEvent("Hello, World!");
        }
    }
}