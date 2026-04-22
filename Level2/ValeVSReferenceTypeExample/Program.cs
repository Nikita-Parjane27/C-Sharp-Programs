using System;
namespace ValueVsReferenceTypeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Value type example
            int a = 5;
            int b = a; // b gets a copy of a's value
            b = 10; // changing b does not affect a

            Console.WriteLine("Value Type Example:");
            Console.WriteLine($"a: {a}"); // Output: 5
            Console.WriteLine($"b: {b}"); // Output: 10

            // Reference type example
            MyClass obj1 = new MyClass { Value = 5 };
            MyClass obj2 = obj1; // obj2 references the same object as obj1
            obj2.Value = 10; // changing obj2's Value changes obj1's Value
        }
    }
}