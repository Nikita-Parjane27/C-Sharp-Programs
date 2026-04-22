using System;
namespace IndexersDemon
{
    class Program
    {
        //demonstrate the use of indexers in a class
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection();
            collection[0] = "Hello";
            collection[1] = "World";

            Console.WriteLine(collection[0]); // Output: Hello
            Console.WriteLine(collection[1]); // Output: World
        }
        
    }
}