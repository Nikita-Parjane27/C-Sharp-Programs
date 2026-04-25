using System;
namespace TryCatchFinally_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Attempt to parse an invalid integer to trigger an exception
                string input = "abc";
                int number = int.Parse(input);
                Console.WriteLine("Parsed number: " + number);
            }
            catch (FormatException ex)
            {
                // Handle the specific exception for format errors
                Console.WriteLine("Error: Invalid format. " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that may occur
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                // This block will always execute, regardless of whether an exception was thrown or not
                Console.WriteLine("Execution of the try-catch block is complete.");
            }
        }
    }
}