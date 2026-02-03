using System;

namespace IntegerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number is positive or Negative
            int number;
            Console.WriteLine("Enter an integer number:");
            number = int.Parse(Console.ReadLine());

            if(number > 0)
            {
                Console.WriteLine("Number " +number + " is positive.");
            }
            else if(number < 0)
            {
                Console.WriteLine("Number " + number + " is negative.");
            }
            else
            {
                Console.WriteLine("Number is zero.");
            }
        }
    }
}