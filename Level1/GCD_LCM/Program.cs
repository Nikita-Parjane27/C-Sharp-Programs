using System;

namespace GCD_LCM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input two numbers
            Console.WriteLine("Enter the first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int num2 = int.Parse(Console.ReadLine());

            // Calculate GCD
            int gcd = CalculateGCD(num1, num2);
            Console.WriteLine("GCD of " + num1 + " and " + num2 + " is: " + gcd);

            // Calculate LCM
            int lcm = CalculateLCM(num1, num2, gcd);
            Console.WriteLine("LCM of " + num1 + " and " + num2 + " is: " + lcm);
        }

        static int CalculateGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int CalculateLCM(int a, int b, int gcd)
        {
            return (a * b) / gcd;
        }
    }
}