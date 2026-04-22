using System;
namespace Enum_Demo
{
    class Program
    {
        enum DaysOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
        static void Main(string[] args)
        {
            DayOfWeek today = DayOfWeek.Friday;
            Console.WriteLine("Today is: " + today);
        }
    }
}