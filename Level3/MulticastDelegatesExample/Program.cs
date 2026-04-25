using System;
namespace MulticastDelegatesExample
{
    class Program
    {
        // Define a delegate that takes an integer and returns void
        delegate void Operation(int x);

        static void Main(string[] args)
        {
            // Create an instance of the delegate and assign it a lambda expression
            Operation printSquare = x => Console.WriteLine($"The square of {x} is {x * x}.");
            Operation printCube = x => Console.WriteLine($"The cube of {x} is {x * x * x}.");

            // Combine the delegates to create a multicast delegate
            Operation combinedOperation = printSquare + printCube;

            // Use the multicast delegate to perform both operations on a number
            int number = 5;
            combinedOperation(number);
        }
    }
}