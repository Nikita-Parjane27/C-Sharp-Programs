using System;
namespace AnagramString
{
    class Program
    {
      //check string anagram
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first string:");
            string str1 = Console.ReadLine();

            Console.WriteLine("Enter the second string:");
            string str2 = Console.ReadLine();

            if (AreAnagrams(str1, str2))
            {
                Console.WriteLine("The strings are anagrams.");
            }
            else
            {
                Console.WriteLine("The strings are not anagrams.");
            }
        }

        static bool AreAnagrams(string s1, string s2)
        {
            // Remove whitespace and convert to lowercase
            s1 = s1.Replace(" ", "").ToLower();
            s2 = s2.Replace(" ", "").ToLower();

            // Sort the characters of both strings
            char[] charArray1 = s1.ToCharArray();
            char[] charArray2 = s2.ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);

            // Compare the sorted character arrays
            return new string(charArray1) == new string(charArray2);
        }  
    }
}