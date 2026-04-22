using System;

namespace Maximum
{
    class Maximum
    {
        static void Main(string[] args)
        {
            int num1, num2, max;
            Console.WriteLine("Enter first number:");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            num2 = int.Parse(Console.ReadLine());
           
           if (num1 >= num2)
            {
                max = num1;
            }
            else
            {
                max = num2;
            }

           
           Console.WriteLine("The maximum of " + num1 + " and " + num2 + " is " + max + ".");
        }
    }
}