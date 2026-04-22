using System;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, reversedNumber = 0;
            Console.WriteLine("Enter a number:");
            number = int.Parse(Console.ReadLine());

            while (number != 0)
            {
                int digit = number % 10;
                reversedNumber = reversedNumber * 10 + digit;
                number /= 10;
            }

            Console.WriteLine("Reversed Number: " + reversedNumber);
        }
    }
}