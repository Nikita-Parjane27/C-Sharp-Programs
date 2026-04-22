using System;

namespace Convert_Celsius_Farenhit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input temperature in Celsius
            Console.WriteLine("Enter temperature in Celsius:");
            double celsius = double.Parse(Console.ReadLine());

            // Convert Celsius to Fahrenheit
            double fahrenheit = (celsius * 9 / 5) + 32;

            // Output the result
            Console.WriteLine(celsius + "°C is equal to " + fahrenheit + "°F");
        }
    }
}