using System;
namespace FunAsyncPredicateExample
{
    class Program
    {
        // Define an asynchronous predicate that takes an integer and returns a boolean
        static async System.Threading.Tasks.Task<bool> IsEvenAsync(int x)
        {
            await System.Threading.Tasks.Task.Delay(100); // Simulate asynchronous work
            return x % 2 == 0;
        }

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            int number = 10;

            // Use the asynchronous predicate to check if the number is even
            bool isEven = await IsEvenAsync(number);

            // Display the result
            Console.WriteLine($"{number} is even: {isEven}");
        }
    }
}