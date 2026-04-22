using System;
 namespace TypeCasting_Example
{
    class Program
    {
        static void Main(string[] args)
        {
             // 1️⃣ Implicit Casting (int → double)
             
        int intValue = 50;
        double implicitResult = intValue;

        Console.WriteLine("----- Implicit Casting -----");
        Console.WriteLine("Integer value: " + intValue);
        Console.WriteLine("Converted to Double: " + implicitResult);

        // 2️⃣ Explicit Casting (double → int)
        double doubleValue = 45.78;
        int explicitResult = (int)doubleValue;

        Console.WriteLine("\n----- Explicit Casting -----");
        Console.WriteLine("Double value: " + doubleValue);
        Console.WriteLine("Converted to Integer: " + explicitResult);

        // 3️⃣ Convert Class (string → int)
        string stringValue = "100";
        int convertResult = Convert.ToInt32(stringValue);

        Console.WriteLine("\n----- Convert Class -----");
        Console.WriteLine("String value: " + stringValue);
        Console.WriteLine("Converted to Integer: " + convertResult);
        }
    }
}