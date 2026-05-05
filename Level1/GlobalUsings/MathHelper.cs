// No using statements needed here either!

class MathHelper
{
    public static double CircleArea(double r)
        => Math.PI * r * r;

    public static int Factorial(int n)
        => n <= 1 ? 1 : n * Factorial(n - 1);

    public static List<int> GetPrimes(int limit)
    {
        var primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            bool isPrime = true;
            for (int j = 2; j < i; j++)
                if (i % j == 0) { isPrime = false; break; }
            if (isPrime) primes.Add(i);
        }
        return primes;
    }
}