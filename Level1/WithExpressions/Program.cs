using System;

namespace WithExpressions
{
    // Record definitions
    record Address(string Street, string City, string State, string Zip);
    record Person(string Name, int Age, string Email, Address Address);
    record Product(string Name, double Price, string Category, int Stock);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Basic With Expression ===");

            var original = new Person(
                "Nikita",
                20,
                "nikita@email.com",
                new Address("MG Road", "Pune", "Maharashtra", "411001")
            );

            Console.WriteLine($"Original: {original}");

            // Create modified copy
            var updated = original with { Age = 21, Email = "nikita.new@email.com" };
            Console.WriteLine($"Updated : {updated}");
            Console.WriteLine($"Original unchanged: {original}");

            Console.WriteLine("\n=== Nested With Expression ===");

            // Modify nested object
            var relocated = original with
            {
                Address = original.Address with { City = "Mumbai", Zip = "400001" }
            };
            Console.WriteLine($"Relocated: {relocated}");

            Console.WriteLine("\n=== Product Updates ===");

            var product = new Product("Laptop", 50000, "Electronics", 100);
            Console.WriteLine($"Original : {product}");

            var discounted = product with { Price = 45000 };
            var outOfStock = product with { Stock = 0 };
            var rebranded = product with { Name = "Gaming Laptop", Price = 75000 };

            Console.WriteLine($"Discounted : {discounted}");
            Console.WriteLine($"OutOfStock : {outOfStock}");
            Console.WriteLine($"Rebranded  : {rebranded}");

            Console.WriteLine("\n=== Equality Check ===");

            var copy = original with { }; // exact copy
            Console.WriteLine($"original == copy : {original == copy}");
            Console.WriteLine($"original == updated : {original == updated}");
        }
    }
}