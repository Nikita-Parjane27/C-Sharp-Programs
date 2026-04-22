using System;
namespace frequency_Character
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char characterToCount = Console.ReadLine()[0];
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == characterToCount)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}