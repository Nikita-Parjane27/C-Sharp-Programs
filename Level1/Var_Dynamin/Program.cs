using System;
namespace Var_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var
            var number = 10; // implicitly typed variable
            Console.WriteLine("Value of number: " + number);    

            //using dynamic
            dynamic dynamicVariable = "Hello, World!"; // dynamic variable
            Console.WriteLine("Value of dynamicVariable: " + dynamicVariable);
            dynamicVariable = 123; // changing the type of dynamic variable
            Console.WriteLine("Value of dynamicVariable after changing type: " + dynamicVariable);
        }
    }
}