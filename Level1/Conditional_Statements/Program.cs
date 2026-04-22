using System;
namespace Conditional_Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 10;

            // if statement
            if (number > 0)
            {
                Console.WriteLine("The number is positive.");
            }

            // if-else statement
            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is odd.");
            }

            // if-else-if statement
            if (number > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine("The number is negative.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}