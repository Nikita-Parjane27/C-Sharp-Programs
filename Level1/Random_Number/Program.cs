using System;
namespace Random_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101); // Generates a random number between 1 and 100
            Console.WriteLine("Generated Random Number: " + randomNumber);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}