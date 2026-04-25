using System;
namespace DelegatesExample
{
    class Program
    {
        // Define a delegate that takes an integer and returns an integer
        delegate int Operation(int x);

        static void Main(string[] args)
        {
            // Create an instance of the delegate and assign it a lambda expression
            Operation square = x => x * x;

            // Use the delegate to calculate the square of a number
            int number = 5;
            int result = square(number);

            // Display the result
            Console.WriteLine($"The square of {number} is {result}.");
        }
    }
}