using System;
namespace CustomException_EXAMPLE
{
    // Define a custom exception class that inherits from Exception
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Simulate a condition that triggers the custom exception
                bool condition = true; // This can be any condition you want to check
                if (condition)
                {
                    throw new CustomException("A custom exception has occurred!");
                }
            }
            catch (CustomException ex)
            {
                // Handle the custom exception
                Console.WriteLine("Caught a custom exception: " + ex.Message);
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