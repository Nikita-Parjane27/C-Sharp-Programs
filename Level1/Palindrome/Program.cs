using System;
using System.Runtime.InteropServices.Marshalling;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter a string:");
            str = Console.ReadLine();
            char[] charArray = str.ToCharArray();

           for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
            {
                if (charArray[i] != charArray[j])
                {
                    Console.WriteLine(str + " is not a palindrome.");
                    return;
                }
            }
            Console.WriteLine(str + " is a palindrome.");
        }
    }
}