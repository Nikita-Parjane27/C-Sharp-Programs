using System;
namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the GenericClass with int type
            GenericClass<int> intInstance = new GenericClass<int>();
            intInstance.SetValue(42);
            Console.WriteLine("Value in intInstance: " + intInstance.GetValue());

            // Create an instance of the GenericClass with string type
            GenericClass<string> stringInstance = new GenericClass<string>();
            stringInstance.SetValue("Hello, Generics!");
            Console.WriteLine("Value in stringInstance: " + stringInstance.GetValue());
        }
    }
}