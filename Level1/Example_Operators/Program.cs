using System;
namespace Example_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Operators in C#");
            int a = 10;
            int b = 5;

            // Arithmetic Operators
            Console.WriteLine("a + b = " + (a + b));
            Console.WriteLine("a - b = " + (a - b));
            Console.WriteLine("a * b = " + (a * b));
            Console.WriteLine("a / b = " + (a / b));
            Console.WriteLine("a % b = " + (a % b));

            // Comparison Operators
            Console.WriteLine("a == b: " + (a == b));
            Console.WriteLine("a != b: " + (a != b));
            Console.WriteLine("a > b: " + (a > b));
            Console.WriteLine("a < b: " + (a < b));
            Console.WriteLine("a >= b: " + (a >= b));
            Console.WriteLine("a <= b: " + (a <= b));

            // Logical Operators
            bool x = true;
            bool y = false;
            Console.WriteLine("x && y: " + (x && y));
            Console.WriteLine("x || y: " + (x || y));
            Console.WriteLine("!x: " + (!x));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}