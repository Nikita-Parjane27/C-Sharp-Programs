using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0, num1 = 1 ;
            for (int i = 2; i < 10; i++)
            {
                int num2 = num + num1;
                Console.Write(num2 + " ");
                num = num1;
                num1 = num2;
            }
        }
    }
}