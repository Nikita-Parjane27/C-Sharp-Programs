using System;
namespace StringFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string formattedString = string.Format("You entered: {0}", input);
            Console.WriteLine(formattedString);
        }
        
    }
}