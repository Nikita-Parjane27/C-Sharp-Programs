using System;
namespace Factorial_Recursion
{
    class Program
    {
        // This program calculates the factorial of a number using recursion.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to calculate its factorial:");
            int n = int.Parse(Console.ReadLine());

            int result = Factorial(n);
            Console.WriteLine($"The factorial of {n} is: {result}");
        }

        static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            else if (n == 0 || n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
    }
}