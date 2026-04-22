using System;
namespace PasswordStrengthValidation
{
    class Program
    {
        //validate password strength
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a password:");
            string password = Console.ReadLine();

            if (IsStrongPassword(password))
            {
                Console.WriteLine("Password is strong.");
            }
            else
            {
                Console.WriteLine("Password is weak. It should be at least 8 characters long and contain a mix of uppercase letters, lowercase letters, numbers, and special characters.");
            }
        }

        static bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsLower(c))
                    hasLowerCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (!char.IsLetterOrDigit(c))
                    hasSpecialChar = true;
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}