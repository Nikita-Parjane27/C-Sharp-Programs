using System;
namespace LambdaExpression_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a lambda expression to calculate the square of a number
            Func<int, int> square = x => x * x;

            // Use the lambda expression to calculate the square of a number
            int number = 5;
            int result = square(number);

            // Display the result
            Console.WriteLine($"The square of {number} is {result}.");
        }
    }
}