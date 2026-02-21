using System;
namespace Area_of_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input length and width of the rectangle
            Console.WriteLine("Enter the length of the rectangle:");
            double length = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the width of the rectangle:");
            double width = double.Parse(Console.ReadLine());

            // Calculate area of the rectangle
            double area = length * width;

            // Output the result
            Console.WriteLine("The area of the rectangle with length " + length + " and width " + width + " is: " + area);
        }
    }
}