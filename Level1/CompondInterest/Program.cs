using System;

namespace CompoundInterest
{
    class Program
    {
        static void Main(string[] args)
        {
            double principal, amount, rate;
            int time;

            Console.WriteLine("Enter Principal amount:");
            principal = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Time in years:");
            time = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Rate of interest:");
            rate = double.Parse(Console.ReadLine());

            amount = principal * Math.Pow((1 + rate / 100), time);
            Console.WriteLine("Amount after " + time + " years is: " + amount);

            double CI = amount - principal;
            Console.WriteLine("Compound Interest is: " + CI);
        }
    }
}
