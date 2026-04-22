using System;
namespace ForLoop_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine("Iteration: " + i);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}