using System;
namespace Demo_Struct
{
    class Program
    {
        struct Point
        {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        static void Main(string[] args)
        {
            Point point1 = new Point(10, 20);
            Console.WriteLine("Point 1: X = " + point1.X + ", Y = " + point1.Y);
        }
    }
}