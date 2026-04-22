using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Enter a number to display its multiplication table:");
            number = int.Parse(Console.ReadLine());

            Console.WriteLine("Multiplication Table of " + number + ":");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(number + " x " + i + " = " + (number * i));
            }
        }
    }
}