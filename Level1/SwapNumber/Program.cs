using System;

namespace SwapNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 78;
            int num2 = 45;
            int temp;

            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("After swapping, first number: " + num1);
            Console.WriteLine("After swapping, second number: " + num2); 
        }
    }
}