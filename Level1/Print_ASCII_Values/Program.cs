using System;
namespace Print_ASCII_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input a character
            Console.WriteLine("Enter a character to get its ASCII value:");
            char inputChar = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Move to the next line

            // Get ASCII value of the character
            int asciiValue = (int)inputChar;

            // Output the result
            Console.WriteLine("The ASCII value of '" + inputChar + "' is: " + asciiValue);
        }
    }
}