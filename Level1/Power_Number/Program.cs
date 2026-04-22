using System;
namespace Power_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the base number:");
            double baseNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the exponent:");
            double exponent = Convert.ToDouble(Console.ReadLine());

            double result = Math.Pow(baseNumber, exponent);
            Console.WriteLine($"{baseNumber} raised to the power of {exponent} is: {result}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}