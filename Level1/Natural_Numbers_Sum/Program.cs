using System;
namespace Natural_Numbers_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for(int i=1; i<=n; i++)
            {
                sum += i;
            }
            Console.WriteLine("The sum of first " + n + " natural numbers is: " + sum);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}