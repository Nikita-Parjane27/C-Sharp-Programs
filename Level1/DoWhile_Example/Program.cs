using System;
namespace DoWhile_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            do
            {
                Console.WriteLine("Iteration: " + i);
                i++;
            } while (i < 10);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}   