using System;
namespace AsyncAwaitExample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Starting the asynchronous operation...");
            string result = await PerformAsyncOperation();
            Console.WriteLine("Asynchronous operation completed. Result: " + result);
        }

        static async System.Threading.Tasks.Task<string> PerformAsyncOperation()
        {
            // Simulate an asynchronous operation (e.g., fetching data from a server)
            await System.Threading.Tasks.Task.Delay(2000); // Simulate a delay of 2 seconds
            return "Data fetched successfully!";
        }
    }
}