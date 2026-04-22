using System;
namespace LowerUpperConver
{
    class Program
    {
        //convert string to lower and upper case
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string lowerCase = input.ToLower(); // Convert the string to lower case
            string upperCase = input.ToUpper(); // Convert the string to upper case

            Console.WriteLine("Lower case: " + lowerCase);
            Console.WriteLine("Upper case: " + upperCase);
        }
    }
}