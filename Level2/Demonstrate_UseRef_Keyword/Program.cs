using System;
namespace Demonstrate_UseRef_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            Console.WriteLine($"Original number: {number}");

            // Using ref to modify the original variable
            ModifyNumber(ref number);
            Console.WriteLine($"Modified number: {number}");
        }

        static void ModifyNumber(ref int num)
        {
            num += 10; // This will modify the original variable passed by reference
        }
    }
}