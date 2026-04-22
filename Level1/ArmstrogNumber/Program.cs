using System;

namespace ArmstrogNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, temp, sum = 0;
            Console.WriteLine("Enter a number:");
            number = int.Parse(Console.ReadLine());
            temp = number;

            while (temp != 0)
            {
                int remainder = temp % 10;
                sum += remainder * remainder * remainder;
                temp /= 10;
            }

            if (sum == number)
            {
                Console.WriteLine(number + " is an Armstrong number.");
            }
            else
            {
                Console.WriteLine(number + " is not an Armstrong number.");
            }
        }
    }
}