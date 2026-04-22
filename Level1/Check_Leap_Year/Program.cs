using System;
namespace Check_Leap_Year
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a year:");
            int year = Convert.ToInt32(Console.ReadLine());
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                Console.WriteLine(year + " is a leap year.");
            }
            else
            {
                Console.WriteLine(year + " is not a leap year.");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}