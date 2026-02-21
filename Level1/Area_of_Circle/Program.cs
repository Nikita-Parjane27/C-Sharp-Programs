using System;
namespace Area_of_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input radius of the circle
            Console.WriteLine("Enter the radius of the circle:");
            double radius = double.Parse(Console.ReadLine());

            // Calculate area of the circle
            double area = Math.PI * Math.Pow(radius, 2);

            // Output the result
            Console.WriteLine("The area of the circle with radius " + radius + " is: " + area);
        }
    }
}