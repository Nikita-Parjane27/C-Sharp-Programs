using System;
using System.Text; // needed for StringBuilder

namespace StringBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i]); // adds each character
            }

            Console.WriteLine(sb.ToString()); // convert back to string
        }
    }
}