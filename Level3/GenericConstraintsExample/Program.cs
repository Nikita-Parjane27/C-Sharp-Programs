using System;
namespace GenericConstraintsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the GenericClass with a type that satisfies the constraint
            GenericClass<SampleClass> sampleInstance = new GenericClass<SampleClass>();
            sampleInstance.SetValue(new SampleClass { Name = "John Doe" });
            Console.WriteLine("Value in sampleInstance: " + sampleInstance.GetValue().Name);
        }
    }

    // Define a sample class to use with the generic class
    public class SampleClass
    {
        public string Name { get; set; }
    }

    // Define a generic class with a constraint that T must be a reference type
    public class GenericClass<T> where T : class
    {
        private T value;

        public void SetValue(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
    }
}