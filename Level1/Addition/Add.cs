using System;

namespace Addition
{
    class Add
    {
        static void Main(string[] args)
        {
            int num1, num2, sum;
            Console.WriteLine("Enter first number:");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            num2 = int.Parse(Console.ReadLine());
            sum = num1 + num2;
            Console.WriteLine("The sum of " + num1 + " and " + num2 + " is " + sum + ".");
        }
    }
}