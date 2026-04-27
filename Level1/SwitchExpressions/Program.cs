using System;

namespace SwitchExpressionsDemo
{
    enum Season { Spring, Summer, Autumn, Winter }

    class Program
    {
        static void Main()
        {
            // 1. Basic switch expression
            Console.WriteLine("=== Basic Switch Expression ===");

            int day = 3;
            string dayName = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Invalid day"
            };

            Console.WriteLine($"Day {day} is {dayName}");

            // 2. Switch expression with calculation
            Console.WriteLine("\n=== Switch with Calculation ===");

            string[] shapes = { "circle", "square", "rectangle", "triangle" };
            double[] values = { 5, 4, 0, 0 };

            for (int i = 0; i < shapes.Length; i++)
            {
                double area = shapes[i] switch
                {
                    "circle"    => Math.PI * values[i] * values[i],
                    "square"    => values[i] * values[i],
                    "rectangle" => 4 * 6,
                    "triangle"  => 0.5 * 6 * 4,
                    _           => 0
                };

                Console.WriteLine($"Area of {shapes[i]}: {area:F2}");
            }

            // 3. Switch expression with enum
            Console.WriteLine("\n=== Switch with Enum ===");

            Season season = Season.Winter;
            string clothing = season switch
            {
                Season.Spring => "Light jacket",
                Season.Summer => "T-shirt and shorts",
                Season.Autumn => "Sweater",
                Season.Winter => "Heavy coat and gloves",
                _             => "Normal clothes"
            };

            Console.WriteLine($"Season: {season} => Wear: {clothing}");

            // 4. Switch expression returning value
            Console.WriteLine("\n=== Switch Returning Value ===");

            string[] members = { "Gold", "Silver", "Bronze", "Regular", "Guest" };

            foreach (var m in members)
                Console.WriteLine($"{m}: {GetDiscount(m)}");

            // 5. Nested switch expression
            Console.WriteLine("\n=== Nested Switch Expression ===");

            Console.WriteLine(GetShipping("India", "Express"));
            Console.WriteLine(GetShipping("USA", "Normal"));
            Console.WriteLine(GetShipping("UK", "Express"));
        }

        // Method for discount
        static string GetDiscount(string memberType) => memberType switch
        {
            "Gold"     => "30% discount",
            "Silver"   => "20% discount",
            "Bronze"   => "10% discount",
            "Regular"  => "5% discount",
            _          => "No discount"
        };

        // Method for shipping
        static string GetShipping(string country, string plan) =>
            country switch
            {
                "India" => plan switch
                {
                    "Express" => "1 day - Rs.200",
                    "Normal"  => "5 days - Rs.50",
                    _         => "7 days - Free"
                },
                "USA" => plan switch
                {
                    "Express" => "2 days - $20",
                    "Normal"  => "7 days - $5",
                    _         => "14 days - Free"
                },
                _ => "International shipping - Contact us"
            };
    }
}