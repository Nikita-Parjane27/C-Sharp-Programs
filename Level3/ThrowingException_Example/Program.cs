using System;
namespace ThrowingException_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Simulate a condition that triggers an exception
                bool condition = true; // This can be any condition you want to check
                if (condition)
                {
                    throw new Exception("An exception has been thrown!");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine("Caught an exception: " + ex.Message);
            }
            finally
            {
                // This block will always execute, regardless of whether an exception was thrown or not
                Console.WriteLine("Execution of the try-catch block is complete.");
            }
        }
    }
}