using System;
namespace DateTimeClass_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDate = DateTime.Now; // using DateTime class to get current date and time
            Console.WriteLine("Current Date and Time: " + currentDate);
            DateTime specificDate = new DateTime(2022, 12, 25); // creating a specific date
            Console.WriteLine("Specific Date: " + specificDate.ToShortDateString());
        }
    }
}