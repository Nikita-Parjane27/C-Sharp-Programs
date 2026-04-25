using System;
namespace ExceptionHandling_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Attempt to divide by zero to trigger an exception
                int numerator = 10;
                int denominator = 0;
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException ex)
            {
                // Handle the specific exception for division by zero
                Console.WriteLine("Error: Cannot divide by zero. " + ex.Message);
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