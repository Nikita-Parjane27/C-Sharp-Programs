using System;

namespace LargestNumber
{
    class Program
    {
        static void Main()
        {
            int num1, num2;
            Console.WriteLine("Enter two Numbers : ");
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());

            if (num1 > num2)
            {
                Console.WriteLine(num1 + " is the largest number.");
            }
            else if (num2 > num1)
            {
                Console.WriteLine(num2 + " is the largest number.");
            }
            else
            {
                Console.WriteLine("Both numbers are equal.");
            }
        }
    }
}