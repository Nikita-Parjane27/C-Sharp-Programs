// ============================================================
//  Program #153 — Banking System
//  Level 4 | C# Programming by Dr Kiran Khandarkar
// ============================================================
//
//  CONCEPTS COVERED:
//    - Inheritance (SavingsAccount, CurrentAccount extend Account)
//    - Abstract class with abstract methods
//    - Polymorphism (WithdrawWithRules behaves differently per type)
//    - Readonly account number generation
//    - Transaction history using List<Transaction>
//    - Enum for transaction type
//    - decimal type for financial precision (never use double for money)
//    - Custom exceptions for banking rules
//    - DateTime for timestamps
//    - Layered architecture (Model / Service / UI)
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem
{
    // ─────────────────────────────────────────────────────────
    //  ENUMS
    // ─────────────────────────────────────────────────────────
    public enum TransactionType { Deposit, Withdrawal, Transfer }
    public enum AccountType     { Savings, Current }

    // ─────────────────────────────────────────────────────────
    //  CUSTOM EXCEPTIONS
    // ─────────────────────────────────────────────────────────
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(decimal balance, decimal amount)
            : base($"Insufficient funds. Balance: ₹{balance:F2}, Requested: ₹{amount:F2}") { }
    }

    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string accNo)
            : base($"Account '{accNo}' not found.") { }
    }

    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string msg) : base(msg) { }
    }

    // ─────────────────────────────────────────────────────────
    //  TRANSACTION MODEL
    // ─────────────────────────────────────────────────────────
    public class Transaction
    {
        public int             Id          { get; set; }
        public TransactionType Type        { get; set; }
        public decimal         Amount      { get; set; }
        public decimal         BalanceAfter{ get; set; }
        public string          Description { get; set; }
        public DateTime        Timestamp   { get; set; } = DateTime.Now;

        public override string ToString() =>
            $"  {Timestamp:dd/MM/yy HH:mm}  {Type,-12}  ₹{Amount,10:F2}  " +
            $"Balance: ₹{BalanceAfter,10:F2}  {Description}";
    }

    // ─────────────────────────────────────────────────────────
    //  ABSTRACT ACCOUNT BASE CLASS
    //  Common fields and behaviour shared by all account types.
    //  WithdrawWithRules() is abstract — each subclass enforces
    //  its own rules (min balance, overdraft, etc.)
    // ─────────────────────────────────────────────────────────
    public abstract class Account
    {
        private static int _counter = 1000;

        public string          AccountNumber { get; }
        public string          HolderName    { get; set; }
        public string          Email         { get; set; }
        public decimal         Balance       { get; protected set; }
        public AccountType     Type          { get; }
        public DateTime        OpenedOn      { get; } = DateTime.Today;

        private readonly List<Transaction> _history = new();
        private int _txId = 1;

        protected Account(string holderName, string email, decimal initialDeposit, AccountType type)
        {
            if (initialDeposit < 0)
                throw new InvalidAmountException("Initial deposit cannot be negative.");

            AccountNumber = $"ACC{++_counter}";
            HolderName    = holderName;
            Email         = email;
            Balance       = initialDeposit;
            Type          = type;

            if (initialDeposit > 0)
                RecordTransaction(TransactionType.Deposit, initialDeposit, "Account opened");
        }

        // ── COMMON OPERATIONS ────────────────────────────────

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be greater than zero.");

            Balance += amount;
            RecordTransaction(TransactionType.Deposit, amount, "Deposit");
        }

        // Calls the abstract rule — subclass decides if withdrawal is allowed
        public void Withdraw(decimal amount, string description = "Withdrawal")
        {
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be greater than zero.");

            WithdrawWithRules(amount, description);   // polymorphic call
        }

        // Transfer to another account
        public void TransferTo(Account target, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Transfer amount must be greater than zero.");

            WithdrawWithRules(amount, $"Transfer to {target.AccountNumber}");
            target.Balance += amount;
            target.RecordTransaction(TransactionType.Transfer, amount,
                $"Transfer from {AccountNumber}");
        }

        public IReadOnlyList<Transaction> GetHistory() => _history.AsReadOnly();

        public Transaction GetLastTransaction() => _history.LastOrDefault();

        // ── ABSTRACT — ENFORCED BY SUBCLASS ──────────────────
        protected abstract void WithdrawWithRules(decimal amount, string description);

        // ── PROTECTED HELPERS ────────────────────────────────
        protected void RecordTransaction(TransactionType type, decimal amount, string desc)
        {
            _history.Add(new Transaction
            {
                Id           = _txId++,
                Type         = type,
                Amount       = amount,
                BalanceAfter = Balance,
                Description  = desc
            });
        }

        public override string ToString() =>
            $"  [{AccountNumber}] {HolderName} | {Type} | Balance: ₹{Balance:F2}";
    }

    // ─────────────────────────────────────────────────────────
    //  SAVINGS ACCOUNT
    //  Rule: Cannot withdraw below minimum balance (₹500)
    // ─────────────────────────────────────────────────────────
    public class SavingsAccount : Account
    {
        public decimal MinimumBalance { get; } = 500m;
        public decimal InterestRate   { get; } = 0.04m; // 4% per annum

        public SavingsAccount(string name, string email, decimal deposit)
            : base(name, email, deposit, AccountType.Savings) { }

        protected override void WithdrawWithRules(decimal amount, string description)
        {
            if (Balance - amount < MinimumBalance)
                throw new InsufficientFundsException(Balance - MinimumBalance, amount);

            Balance -= amount;
            RecordTransaction(TransactionType.Withdrawal, amount, description);
        }

        // Apply annual interest to balance
        public decimal ApplyInterest()
        {
            decimal interest = Math.Round(Balance * InterestRate, 2);
            Balance += interest;
            RecordTransaction(TransactionType.Deposit, interest,
                $"Interest credited ({InterestRate * 100}% p.a.)");
            return interest;
        }
    }

    // ─────────────────────────────────────────────────────────
    //  CURRENT ACCOUNT
    //  Rule: Overdraft allowed up to a limit
    // ─────────────────────────────────────────────────────────
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; } = 10_000m;

        public CurrentAccount(string name, string email, decimal deposit)
            : base(name, email, deposit, AccountType.Current) { }

        protected override void WithdrawWithRules(decimal amount, string description)
        {
            if (Balance - amount < -OverdraftLimit)
                throw new InsufficientFundsException(Balance + OverdraftLimit, amount);

            Balance -= amount;
            RecordTransaction(TransactionType.Withdrawal, amount, description);
        }
    }

    // ─────────────────────────────────────────────────────────
    //  BANK SERVICE (Business Logic Layer)
    // ─────────────────────────────────────────────────────────
    public class BankService
    {
        private readonly Dictionary<string, Account> _accounts = new();

        public Account OpenSavingsAccount(string name, string email, decimal deposit)
        {
            var acc = new SavingsAccount(name, email, deposit);
            _accounts[acc.AccountNumber] = acc;
            return acc;
        }

        public Account OpenCurrentAccount(string name, string email, decimal deposit)
        {
            var acc = new CurrentAccount(name, email, deposit);
            _accounts[acc.AccountNumber] = acc;
            return acc;
        }

        public Account GetAccount(string accNo) =>
            _accounts.TryGetValue(accNo, out var a) ? a
            : throw new AccountNotFoundException(accNo);

        public IEnumerable<Account> GetAllAccounts() => _accounts.Values;

        public void Deposit(string accNo, decimal amount) =>
            GetAccount(accNo).Deposit(amount);

        public void Withdraw(string accNo, decimal amount) =>
            GetAccount(accNo).Withdraw(amount);

        public void Transfer(string fromAccNo, string toAccNo, decimal amount)
        {
            var from = GetAccount(fromAccNo);
            var to   = GetAccount(toAccNo);
            from.TransferTo(to, amount);
        }

        public decimal ApplyInterest(string accNo)
        {
            if (GetAccount(accNo) is SavingsAccount sa)
                return sa.ApplyInterest();
            throw new InvalidOperationException("Interest only applies to Savings accounts.");
        }

        public (int total, decimal totalBalance, int savings, int current) GetStats()
        {
            var all = _accounts.Values.ToList();
            return (
                all.Count,
                all.Sum(a => a.Balance),
                all.Count(a => a.Type == AccountType.Savings),
                all.Count(a => a.Type == AccountType.Current)
            );
        }
    }

    // ─────────────────────────────────────────────────────────
    //  CONSOLE UI
    // ─────────────────────────────────────────────────────────
    public class ConsoleUI
    {
        private readonly BankService _bank = new BankService();

        public void Run()
        {
            SeedData();
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case "1":  OpenAccount();      break;
                        case "2":  ViewAllAccounts();  break;
                        case "3":  ViewAccount();      break;
                        case "4":  Deposit();          break;
                        case "5":  Withdraw();         break;
                        case "6":  Transfer();         break;
                        case "7":  ViewHistory();      break;
                        case "8":  ApplyInterest();    break;
                        case "9":  ShowStats();        break;
                        case "0":  Console.WriteLine("  Goodbye!"); return;
                        default:   Warn("Invalid option."); break;
                    }
                }
                catch (Exception ex) { Warn(ex.Message); }

                Console.WriteLine();
                Console.Write("  Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void ShowMenu()
        {
            var (total, totalBal, savings, current) = _bank.GetStats();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine( "  ║            BANKING SYSTEM                ║");
            Console.WriteLine($"  ║  Accounts: {total,-5} Total Funds: ₹{totalBal,10:F2}  ║");
            Console.WriteLine( "  ╠══════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine( "  ║  1. Open Account     2. View All         ║");
            Console.WriteLine( "  ║  3. View Account     4. Deposit           ║");
            Console.WriteLine( "  ║  5. Withdraw         6. Transfer          ║");
            Console.WriteLine( "  ║  7. Transaction History                   ║");
            Console.WriteLine( "  ║  8. Apply Interest   9. Bank Stats        ║");
            Console.WriteLine( "  ║  0. Exit                                  ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("  Choose: ");
        }

        private void OpenAccount()
        {
            Header("OPEN ACCOUNT");
            Console.WriteLine("  Type: 1. Savings   2. Current");
            Console.Write("  Choose: ");
            string type = Console.ReadLine()?.Trim();

            string  name    = Prompt("Full Name");
            string  email   = Prompt("Email");
            decimal deposit = ReadDecimal("Initial Deposit (₹)");

            Account acc = type == "2"
                ? _bank.OpenCurrentAccount(name, email, deposit)
                : _bank.OpenSavingsAccount(name, email, deposit);

            Success($"Account opened! Account Number: {acc.AccountNumber}");
        }

        private void ViewAllAccounts()
        {
            Header("ALL ACCOUNTS");
            var accounts = _bank.GetAllAccounts().ToList();
            if (!accounts.Any()) { Console.WriteLine("  No accounts."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"Acc No",-10} {"Name",-20} {"Type",-10} {"Balance",12}");
            Console.WriteLine("  " + new string('─', 56));
            Console.ResetColor();

            foreach (var a in accounts)
                Console.WriteLine($"  {a.AccountNumber,-10} {a.HolderName,-20} {a.Type,-10} ₹{a.Balance,10:F2}");
        }

        private void ViewAccount()
        {
            Header("ACCOUNT DETAILS");
            string accNo = Prompt("Account Number");
            var    acc   = _bank.GetAccount(accNo);

            Console.WriteLine();
            Console.WriteLine($"  Account No  : {acc.AccountNumber}");
            Console.WriteLine($"  Holder      : {acc.HolderName}");
            Console.WriteLine($"  Email       : {acc.Email}");
            Console.WriteLine($"  Type        : {acc.Type}");
            Console.WriteLine($"  Balance     : ₹{acc.Balance:F2}");
            Console.WriteLine($"  Opened On   : {acc.OpenedOn:dd MMM yyyy}");

            if (acc is SavingsAccount sa)
            {
                Console.WriteLine($"  Min Balance : ₹{sa.MinimumBalance:F2}");
                Console.WriteLine($"  Interest    : {sa.InterestRate * 100}% p.a.");
            }
            else if (acc is CurrentAccount ca)
            {
                Console.WriteLine($"  Overdraft   : ₹{ca.OverdraftLimit:F2}");
            }
        }

        private void Deposit()
        {
            Header("DEPOSIT");
            string  accNo  = Prompt("Account Number");
            decimal amount = ReadDecimal("Amount (₹)");
            _bank.Deposit(accNo, amount);
            Success($"₹{amount:F2} deposited. New balance: ₹{_bank.GetAccount(accNo).Balance:F2}");
        }

        private void Withdraw()
        {
            Header("WITHDRAW");
            string  accNo  = Prompt("Account Number");
            decimal amount = ReadDecimal("Amount (₹)");
            _bank.Withdraw(accNo, amount);
            Success($"₹{amount:F2} withdrawn. New balance: ₹{_bank.GetAccount(accNo).Balance:F2}");
        }

        private void Transfer()
        {
            Header("TRANSFER");
            string  from   = Prompt("From Account Number");
            string  to     = Prompt("To Account Number");
            decimal amount = ReadDecimal("Amount (₹)");
            _bank.Transfer(from, to, amount);
            Success($"₹{amount:F2} transferred from {from} to {to}.");
        }

        private void ViewHistory()
        {
            Header("TRANSACTION HISTORY");
            string accNo   = Prompt("Account Number");
            var    history = _bank.GetAccount(accNo).GetHistory();

            if (!history.Any()) { Console.WriteLine("  No transactions yet."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  {"Date",-14} {"Type",-12} {"Amount",12} {"Balance",14} {"Description"}");
            Console.WriteLine("  " + new string('─', 75));
            Console.ResetColor();

            foreach (var t in history)
            {
                Console.ForegroundColor = t.Type == TransactionType.Deposit
                    ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"  {t.Timestamp:dd/MM/yy HH:mm}  {t.Type,-12} " +
                                  $"₹{t.Amount,10:F2}  ₹{t.BalanceAfter,10:F2}  {t.Description}");
                Console.ResetColor();
            }
        }

        private void ApplyInterest()
        {
            Header("APPLY INTEREST");
            string  accNo    = Prompt("Savings Account Number");
            decimal interest = _bank.ApplyInterest(accNo);
            Success($"Interest of ₹{interest:F2} credited. New balance: ₹{_bank.GetAccount(accNo).Balance:F2}");
        }

        private void ShowStats()
        {
            Header("BANK STATISTICS");
            var (total, totalBal, savings, current) = _bank.GetStats();
            Console.WriteLine($"  Total Accounts   : {total}");
            Console.WriteLine($"  Savings Accounts : {savings}");
            Console.WriteLine($"  Current Accounts : {current}");
            Console.WriteLine($"  Total Funds      : ₹{totalBal:F2}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Top 3 Accounts by Balance:");
            Console.ResetColor();

            _bank.GetAllAccounts()
                .OrderByDescending(a => a.Balance)
                .Take(3)
                .ToList()
                .ForEach(a => Console.WriteLine($"    {a.AccountNumber}  {a.HolderName,-18}  ₹{a.Balance:F2}"));
        }

        // ── SEED DATA ────────────────────────────────────────
        private void SeedData()
        {
            var a1 = _bank.OpenSavingsAccount("Aisha Sharma", "aisha@example.com", 15000);
            var a2 = _bank.OpenSavingsAccount("Rohan Mehta",  "rohan@example.com", 8000);
            var a3 = _bank.OpenCurrentAccount("Priya Enterprises", "priya@biz.com", 50000);

            // A few transactions for demo
            _bank.Deposit(a1.AccountNumber, 5000);
            _bank.Withdraw(a2.AccountNumber, 2000);
            _bank.Transfer(a1.AccountNumber, a2.AccountNumber, 3000);
        }

        // ── HELPERS ──────────────────────────────────────────
        private string  Prompt(string label) { Console.Write($"  {label}: "); return Console.ReadLine()?.Trim() ?? ""; }
        private decimal ReadDecimal(string label)
        {
            while (true)
            {
                Console.Write($"  {label}: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal v) && v >= 0) return v;
                Warn("Enter a valid positive amount.");
            }
        }
        private void Header(string t)  { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"  ── {t} ──"); Console.ResetColor(); }
        private void Success(string m) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("  ✔ " + m); Console.ResetColor(); }
        private void Warn(string m)    { Console.ForegroundColor = ConsoleColor.Red;   Console.WriteLine("  ✘ " + m); Console.ResetColor(); }
    }

    // ─────────────────────────────────────────────────────────
    //  ENTRY POINT
    // ─────────────────────────────────────────────────────────
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            new ConsoleUI().Run();
        }
    }
}