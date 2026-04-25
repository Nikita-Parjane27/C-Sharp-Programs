using System;
namespace ExtensionMethodsExample
{
    // Define an extension method for the string class
    public static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Use the extension method to reverse a string
            string original = "Hello, World!";
            string reversed = original.Reverse();

            // Display the original and reversed strings
            Console.WriteLine($"Original string: {original}");
            Console.WriteLine($"Reversed string: {reversed}");
        }
    }
}