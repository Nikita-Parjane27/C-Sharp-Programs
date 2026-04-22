using System;
namespace Nullable_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            //demonstrate nullable type
            int? nullableInt = null; // nullable integer
            Console.WriteLine("Nullable integer value: " + nullableInt);
            if (nullableInt.HasValue)
            {
                Console.WriteLine("Value: " + nullableInt.Value);
            }
            else
            {
                Console.WriteLine("No value assigned to nullable integer.");
            }
            // Assigning a value to nullable integer
            nullableInt = 42;
            Console.WriteLine("Nullable integer value after assignment: " + nullableInt);
            if (nullableInt.HasValue)
            {
                Console.WriteLine("Value: " + nullableInt.Value);
            }
            else
            {
                Console.WriteLine("No value assigned to nullable integer.");
            }     
        }
    }
}