using System;
namespace AnonymsMethodsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define an anonymous method to calculate the sum of two numbers
            Func<int, int, int> sum = delegate (int a, int b)
            {
                return a + b;
            };

            // Use the anonymous method to calculate the sum of two numbers
            int num1 = 10;
            int num2 = 20;
            int result = sum(num1, num2);

            // Display the result
            Console.WriteLine($"The sum of {num1} and {num2} is {result}.");
        }
    }
}