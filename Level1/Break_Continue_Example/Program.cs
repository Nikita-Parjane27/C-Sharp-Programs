using System;
namespace Break_Continue_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using break statement:");
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("Breaking the loop at i = " + i);
                    break;
                }
                Console.WriteLine("Iteration: " + i);
            }

            Console.WriteLine("\nUsing continue statement:");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Skipping even number: " + i);
                    continue;
                }
                Console.WriteLine("Iteration: " + i);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}