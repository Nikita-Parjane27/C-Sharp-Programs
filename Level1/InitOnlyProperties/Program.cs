using System;
using System.Collections.Generic;

namespace InitOnlyDemo
{
    // 1. Basic init-only property
    class Student
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }

        public void Display()
            => Console.WriteLine($"ID: {Id} | Name: {Name} | Age: {Age}");
    }

    // 2. Init-only with validation
    class BankAccount
    {
        private string _accountNumber;

        public string AccountNumber
        {
            get => _accountNumber;
            init
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Account number cannot be empty!");
                if (value.Length != 10)
                    throw new ArgumentException("Account number must be 10 digits!");
                _accountNumber = value;
            }
        }

        public string Owner { get; init; }
        public double Balance { get; init; }
    }

    // 3. Immutable configuration class
    class Configuration
    {
        public string ServerUrl { get; init; }
        public int Port { get; init; }
        public string Database { get; init; }
        public bool IsSSL { get; init; }

        public override string ToString() =>
            $"Server: {ServerUrl}:{Port} | DB: {Database} | SSL: {IsSSL}";
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Init-Only Properties ===");

            var student = new Student { Id = 1, Name = "Nikita", Age = 20 };
            student.Display();

            Console.WriteLine("\n=== Bank Account ===");

            var account = new BankAccount
            {
                AccountNumber = "1234567890",
                Owner = "Nikita",
                Balance = 50000
            };

            Console.WriteLine($"Account: {account.AccountNumber}");
            Console.WriteLine($"Owner  : {account.Owner}");
            Console.WriteLine($"Balance: {account.Balance:C}");

            Console.WriteLine("\n=== Configuration ===");

            var config = new Configuration
            {
                ServerUrl = "https://myserver.com",
                Port = 5432,
                Database = "MyAppDB",
                IsSSL = true
            };

            Console.WriteLine(config);

            Console.WriteLine("\n=== Multiple Students ===");

            var students = new List<Student>
            {
                new() { Id = 1, Name = "Nikita",    Age = 20 },
                new() { Id = 2, Name = "Ashwini",   Age = 21 },
                new() { Id = 3, Name = "Shubhangi", Age = 22 }
            };

            foreach (var s in students)
                s.Display();
        }
    }
}