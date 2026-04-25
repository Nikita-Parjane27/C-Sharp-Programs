using System;
namespace SealedClassDemon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the SealedClass
            SealedClass mySealedClass = new SealedClass();
            // Call a method to display a message
            mySealedClass.DisplayMessage();
        }
    }
}