using System;

namespace SumDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, sum = 0;
            Console.WriteLine("Enter a number:");
            number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            Console.WriteLine("Sum of digits: " + sum);
        }
    }
}