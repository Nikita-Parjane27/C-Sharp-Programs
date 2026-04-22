using System;
namespace WprddsCount_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    count++;
                }
            }

            // Add 1 to count to account for the last word
            Console.WriteLine(count + 1);
        }
    }
}