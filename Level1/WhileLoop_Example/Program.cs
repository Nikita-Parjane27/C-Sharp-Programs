using System;
namespace WhileLoop_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine("Iteration: " + i);
                i++;
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}