using System;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //print prime numbers between 1 to 20
            for (int num = 1; num <= 20; num++)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime && num > 1)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}