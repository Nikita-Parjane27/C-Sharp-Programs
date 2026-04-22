using System;

namespace SimpleInterest
{
    class Program
    {
        static void Main(string[] args)
        {
            int principle, year, rate, SI;
            Console.WriteLine("Enter Principle amount: ");
            principle = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter Time in years: ");
            year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Rate of interest: ");
            rate = int.Parse(Console.ReadLine());

            SI = (principle * year * rate) / 100;
            Console.WriteLine("Simple Interest is: " + SI);
        }
    }
}