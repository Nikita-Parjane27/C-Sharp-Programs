using System;
namespace StackandQueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Stack to store integers
            System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();

            // Push some integers onto the Stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            // Display the contents of the Stack
            Console.WriteLine("Contents of the Stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // Create a Queue to store integers
            System.Collections.Generic.Queue<int> queue = new System.Collections.Generic.Queue<int>();

            // Enqueue some integers into the Queue
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            // Display the contents of the Queue
            Console.WriteLine("\nContents of the Queue:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}