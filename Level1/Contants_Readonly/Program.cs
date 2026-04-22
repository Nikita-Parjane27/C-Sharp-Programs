using System;
namespace ConstantsandReadonly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Constants and Readonly Fields in C#");
            //using a constant
            Console.WriteLine("The value of Pi is: " + Math.PI);
            //using a readonly field
            Console.WriteLine("The current year is: " + DateTime.Now.Year);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    } 
}
