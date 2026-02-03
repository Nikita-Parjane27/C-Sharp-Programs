using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, factorial = 1;
            Console.WriteLine("Enter a number to calculate its factorial:");
            number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The factorial of " + number + " is " + factorial + ".");
        }
    }
}