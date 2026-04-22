using System;
namespace ValidateEmailFormat
{
    class Program
    {
        //validate email format
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an email address:");
            string email = Console.ReadLine();

            if (IsValidEmail(email))
            {
                Console.WriteLine("The email address is valid.");
            }
            else
            {
                Console.WriteLine("The email address is invalid.");
            }
        }

        static bool IsValidEmail(string email)
        {
            // Basic validation for email format
            if (string.IsNullOrWhiteSpace(email))
                return false;

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            return atIndex > 0 && dotIndex > atIndex + 1 && dotIndex < email.Length - 1;
        }
    }
}
