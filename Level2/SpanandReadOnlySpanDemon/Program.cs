using System;
namespace SpanandReadOnlySpanDemon
{
    class Program
    {
        //demonstrate the use of Span and ReadOnlySpan in C#
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            ReadOnlySpan<char> readOnlySpan = input.AsSpan();
            Span<char> span = stackalloc char[readOnlySpan.Length];
            readOnlySpan.CopyTo(span);

            Console.WriteLine("ReadOnlySpan: " + readOnlySpan.ToString());
            Console.WriteLine("Span: " + span.ToString());
        }
        
    }
}