using System;
namespace ImmutabilityStringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string modifiedString = ModifyString(input);
            Console.WriteLine("Modified String: " + modifiedString);
            Console.WriteLine("Original String: " + input);
        }

        static string ModifyString(string str)
        {
            // Attempting to modify the string by concatenating " World"
            str += " World";
            return str;
        }
    }
}