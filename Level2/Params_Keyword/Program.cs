using System;
namespace Params_Keyword
{
    class Program
    {
        //77. Program to demonstrate params keyword 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers to sum (separated by spaces):");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            int[] numbers = Array.ConvertAll(parts, int.Parse);
            int result = SumNumbers(numbers);
            Console.WriteLine($"The sum of the numbers is: {result}");
        }
    }
}