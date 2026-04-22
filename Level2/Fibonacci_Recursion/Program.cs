using System;
namespace Fibonacci_Recursion
{
    class Program
    {
        // This program calculates the Fibonacci number using recursion.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the position in the Fibonacci sequence:");
            int n = int.Parse(Console.ReadLine());

            int result = Fibonacci(n);
            Console.WriteLine($"The {n}th Fibonacci number is: {result}");
        }

        static int Fibonacci(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}