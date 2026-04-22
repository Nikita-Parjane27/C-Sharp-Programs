using System;
namespace Days_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //converting days into months, year,weeks
            Console.WriteLine("Enter number of days:");
            int days = Convert.ToInt32(Console.ReadLine());
            int years = days / 365;
            int months = (days % 365) / 30;
            int weeks = ((days % 365) % 30) / 7;    
            int remainingDays = ((days % 365) % 30) % 7;
            Console.WriteLine(days + " days is approximately " + years + " years, " +
                months + " months, " + weeks + " weeks and " + remainingDays + " days.");
            Console.WriteLine("Press any key to exit...");  
            Console.ReadKey();
        }
    }
}