using System;
namespace MultithreadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new thread to run the PrintNumbers method
            System.Threading.Thread thread = new System.Threading.Thread(PrintNumbers);
            thread.Start();

            // Main thread continues to execute
            Console.WriteLine("Main thread is doing other work...");

            // Wait for the thread to finish
            thread.Join();
            Console.WriteLine("Thread has finished execution.");
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Number: {i}");
                System.Threading.Thread.Sleep(1000); // Simulate work by sleeping for 1 second
            }
        }
    }
}