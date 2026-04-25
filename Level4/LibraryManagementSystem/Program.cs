// ============================================================
//  Program #152 — Library Management System
//  Level 4 | C# Programming by Dr Kiran Khandarkar
// ============================================================
//
//  CONCEPTS COVERED:
//    - Multiple related classes (Book, Member, BorrowRecord)
//    - Relationships between entities (Member borrows Books)
//    - DateTime for due dates and overdue calculation
//    - Dictionary<int, T> for fast lookup
//    - LINQ with multiple collections
//    - Enum for book status
//    - Custom exceptions
//    - Layered architecture (Model / Service / UI)
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // ─────────────────────────────────────────────────────────
    //  ENUMS
    // ─────────────────────────────────────────────────────────
    public enum BookStatus { Available, Borrowed }

    // ─────────────────────────────────────────────────────────
    //  CUSTOM EXCEPTIONS
    // ─────────────────────────────────────────────────────────
    public class BookNotFoundException    : Exception { public BookNotFoundException(int id)   : base($"Book with ID {id} not found.") { } }
    public class MemberNotFoundException : Exception { public MemberNotFoundException(int id)  : base($"Member with ID {id} not found.") { } }
    public class BookNotAvailableException: Exception { public BookNotAvailableException(string title) : base($"'{title}' is currently borrowed.") { } }
    public class BookNotBorrowedException : Exception { public BookNotBorrowedException(string title)  : base($"'{title}' is not currently borrowed.") { } }

    // ─────────────────────────────────────────────────────────
    //  MODELS
    // ─────────────────────────────────────────────────────────
    public class Book
    {
        public int        Id       { get; set; }
        public string     Title    { get; set; }
        public string     Author   { get; set; }
        public string     Genre    { get; set; }
        public BookStatus Status   { get; set; } = BookStatus.Available;

        public Book(int id, string title, string author, string genre)
        {
            Id     = id;
            Title  = title;
            Author = author;
            Genre  = genre;
        }

        public override string ToString() =>
            $"  [{Id}] \"{Title}\" by {Author} | Genre: {Genre} | Status: {Status}";
    }

    public class Member
    {
        public int    Id      { get; set; }
        public string Name    { get; set; }
        public string Email   { get; set; }
        public string Phone   { get; set; }

        public Member(int id, string name, string email, string phone)
        {
            Id    = id;
            Name  = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString() =>
            $"  [{Id}] {Name} | {Email} | {Phone}";
    }

    // BorrowRecord links a Member to a Book with dates
    public class BorrowRecord
    {
        public int      Id           { get; set; }
        public int      BookId       { get; set; }
        public int      MemberId     { get; set; }
        public DateTime BorrowedOn   { get; set; }
        public DateTime DueDate      { get; set; }
        public DateTime? ReturnedOn  { get; set; }  // null = still borrowed

        public bool IsOverdue  => ReturnedOn == null && DateTime.Today > DueDate;
        public bool IsReturned => ReturnedOn != null;

        public int OverdueDays =>
            IsOverdue ? (DateTime.Today - DueDate).Days : 0;

        public double Fine => OverdueDays * 5.0; // ₹5 per overdue day
    }

    // ─────────────────────────────────────────────────────────
    //  LIBRARY SERVICE (Business Logic Layer)
    // ─────────────────────────────────────────────────────────
    public class LibraryService
    {
        // Dictionaries give O(1) lookup by ID — better than List.Find()
        private readonly Dictionary<int, Book>         _books   = new();
        private readonly Dictionary<int, Member>       _members = new();
        private readonly List<BorrowRecord>            _records = new();

        private int _nextBookId   = 1;
        private int _nextMemberId = 1;
        private int _nextRecordId = 1;

        // ── BOOK CRUD ──────────────────────────────────────
        public Book AddBook(string title, string author, string genre)
        {
            var book = new Book(_nextBookId++, title, author, genre);
            _books[book.Id] = book;
            return book;
        }

        public Book GetBook(int id) =>
            _books.TryGetValue(id, out var b) ? b : throw new BookNotFoundException(id);

        public IEnumerable<Book> GetAllBooks() => _books.Values;

        public IEnumerable<Book> SearchBooks(string keyword) =>
            _books.Values.Where(b =>
                b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Genre.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book.Status == BookStatus.Borrowed)
                throw new InvalidOperationException($"Cannot delete '{book.Title}' — it is currently borrowed.");
            _books.Remove(id);
        }

        // ── MEMBER CRUD ────────────────────────────────────
        public Member AddMember(string name, string email, string phone)
        {
            var member = new Member(_nextMemberId++, name, email, phone);
            _members[member.Id] = member;
            return member;
        }

        public Member GetMember(int id) =>
            _members.TryGetValue(id, out var m) ? m : throw new MemberNotFoundException(id);

        public IEnumerable<Member> GetAllMembers() => _members.Values;

        // ── BORROW / RETURN ────────────────────────────────
        public BorrowRecord BorrowBook(int bookId, int memberId, int dueDays = 14)
        {
            var book   = GetBook(bookId);
            var member = GetMember(memberId);

            if (book.Status == BookStatus.Borrowed)
                throw new BookNotAvailableException(book.Title);

            book.Status = BookStatus.Borrowed;

            var record = new BorrowRecord
            {
                Id        = _nextRecordId++,
                BookId    = bookId,
                MemberId  = memberId,
                BorrowedOn = DateTime.Today,
                DueDate   = DateTime.Today.AddDays(dueDays)
            };

            _records.Add(record);
            return record;
        }

        public BorrowRecord ReturnBook(int bookId)
        {
            var book   = GetBook(bookId);

            if (book.Status == BookStatus.Available)
                throw new BookNotBorrowedException(book.Title);

            // Find the active borrow record for this book
            var record = _records.FirstOrDefault(r => r.BookId == bookId && !r.IsReturned)
                ?? throw new Exception("Borrow record not found.");

            record.ReturnedOn = DateTime.Today;
            book.Status       = BookStatus.Available;
            return record;
        }

        // ── QUERIES ────────────────────────────────────────
        public IEnumerable<BorrowRecord> GetActiveBorrows() =>
            _records.Where(r => !r.IsReturned);

        public IEnumerable<BorrowRecord> GetOverdueRecords() =>
            _records.Where(r => r.IsOverdue);

        public IEnumerable<BorrowRecord> GetMemberHistory(int memberId) =>
            _records.Where(r => r.MemberId == memberId);

        // Convenience: resolve names for display
        public string BookTitle(int id)   => _books.TryGetValue(id, out var b)  ? b.Title  : "Unknown";
        public string MemberName(int id)  => _members.TryGetValue(id, out var m) ? m.Name  : "Unknown";

        public (int total, int available, int borrowed) BookStats() =>
        (
            _books.Count,
            _books.Values.Count(b => b.Status == BookStatus.Available),
            _books.Values.Count(b => b.Status == BookStatus.Borrowed)
        );
    }

    // ─────────────────────────────────────────────────────────
    //  CONSOLE UI (Presentation Layer)
    // ─────────────────────────────────────────────────────────
    public class ConsoleUI
    {
        private readonly LibraryService _lib = new LibraryService();

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
                        // Books
                        case "1": AddBook();          break;
                        case "2": ViewAllBooks();     break;
                        case "3": SearchBooks();      break;
                        case "4": DeleteBook();       break;
                        // Members
                        case "5": AddMember();        break;
                        case "6": ViewAllMembers();   break;
                        // Borrow / Return
                        case "7": BorrowBook();       break;
                        case "8": ReturnBook();       break;
                        case "9": ViewActiveBorrows();break;
                        case "10": ViewOverdue();     break;
                        case "11": ViewMemberHistory();break;
                        case "0":
                            Console.WriteLine("  Goodbye!"); return;
                        default:
                            Warn("Invalid option."); break;
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
            var (total, available, borrowed) = _lib.BookStats();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine( "  ║         LIBRARY MANAGEMENT SYSTEM        ║");
            Console.WriteLine($"  ║  Books: {total,-5} Available: {available,-5} Borrowed: {borrowed,-5}║");
            Console.WriteLine( "  ╠══════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine( "  ║  BOOKS                                   ║");
            Console.WriteLine( "  ║   1. Add Book      2. View All Books      ║");
            Console.WriteLine( "  ║   3. Search Books  4. Delete Book         ║");
            Console.WriteLine( "  ║  MEMBERS                                  ║");
            Console.WriteLine( "  ║   5. Add Member    6. View All Members    ║");
            Console.WriteLine( "  ║  BORROW / RETURN                         ║");
            Console.WriteLine( "  ║   7. Borrow Book   8. Return Book         ║");
            Console.WriteLine( "  ║   9. Active Borrows  10. Overdue Books    ║");
            Console.WriteLine( "  ║  11. Member History   0. Exit             ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("  Choose: ");
        }

        // ── BOOK ACTIONS ─────────────────────────────────────
        private void AddBook()
        {
            Header("ADD BOOK");
            string title  = Prompt("Title");
            string author = Prompt("Author");
            string genre  = Prompt("Genre");
            var b = _lib.AddBook(title, author, genre);
            Success($"Book added with ID {b.Id}.");
        }

        private void ViewAllBooks()
        {
            Header("ALL BOOKS");
            var books = _lib.GetAllBooks().ToList();
            if (!books.Any()) { Console.WriteLine("  No books found."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"ID",-4} {"Title",-28} {"Author",-18} {"Genre",-12} {"Status"}");
            Console.WriteLine("  " + new string('─', 72));
            Console.ResetColor();

            foreach (var b in books)
            {
                Console.ForegroundColor = b.Status == BookStatus.Borrowed ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine($"  {b.Id,-4} {b.Title,-28} {b.Author,-18} {b.Genre,-12} {b.Status}");
                Console.ResetColor();
            }
        }

        private void SearchBooks()
        {
            Header("SEARCH BOOKS");
            string kw      = Prompt("Keyword (title / author / genre)");
            var    results = _lib.SearchBooks(kw).ToList();
            if (!results.Any()) { Console.WriteLine("  No results found."); return; }
            Console.WriteLine($"  {results.Count} result(s):\n");
            foreach (var b in results) Console.WriteLine(b);
        }

        private void DeleteBook()
        {
            Header("DELETE BOOK");
            int id = ReadInt("Book ID");
            var b  = _lib.GetBook(id);
            Console.WriteLine($"\n  Delete: {b.Title}? (yes/no): ");
            if (Console.ReadLine()?.Trim().ToLower() == "yes")
            { _lib.DeleteBook(id); Success("Book deleted."); }
            else Console.WriteLine("  Cancelled.");
        }

        // ── MEMBER ACTIONS ───────────────────────────────────
        private void AddMember()
        {
            Header("ADD MEMBER");
            string name  = Prompt("Name");
            string email = Prompt("Email");
            string phone = Prompt("Phone");
            var m = _lib.AddMember(name, email, phone);
            Success($"Member registered with ID {m.Id}.");
        }

        private void ViewAllMembers()
        {
            Header("ALL MEMBERS");
            var members = _lib.GetAllMembers().ToList();
            if (!members.Any()) { Console.WriteLine("  No members."); return; }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"ID",-4} {"Name",-20} {"Email",-25} {"Phone"}");
            Console.WriteLine("  " + new string('─', 60));
            Console.ResetColor();
            foreach (var m in members)
                Console.WriteLine($"  {m.Id,-4} {m.Name,-20} {m.Email,-25} {m.Phone}");
        }

        // ── BORROW / RETURN ACTIONS ──────────────────────────
        private void BorrowBook()
        {
            Header("BORROW BOOK");
            ViewAllBooks();
            Console.WriteLine();
            int bookId   = ReadInt("Book ID to borrow");
            ViewAllMembers();
            Console.WriteLine();
            int memberId = ReadInt("Member ID");
            int days     = ReadInt("Loan period in days (default 14)");
            if (days <= 0) days = 14;

            var record = _lib.BorrowBook(bookId, memberId, days);
            Success($"Book borrowed! Due date: {record.DueDate:dd MMM yyyy}");
        }

        private void ReturnBook()
        {
            Header("RETURN BOOK");
            // Show only borrowed books
            var borrowed = _lib.GetAllBooks().Where(b => b.Status == BookStatus.Borrowed).ToList();
            if (!borrowed.Any()) { Console.WriteLine("  No books currently borrowed."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"ID",-4} {"Title",-28} {"Author"}");
            Console.WriteLine("  " + new string('─', 50));
            Console.ResetColor();
            foreach (var b in borrowed)
                Console.WriteLine($"  {b.Id,-4} {b.Title,-28} {b.Author}");

            Console.WriteLine();
            int bookId = ReadInt("Book ID to return");
            var record = _lib.ReturnBook(bookId);

            Console.WriteLine();
            if (record.IsOverdue || record.OverdueDays > 0)
            {
                int overdueDays = (DateTime.Today - record.DueDate).Days;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  ⚠  Book was {overdueDays} day(s) overdue.");
                Console.WriteLine($"  ⚠  Fine: ₹{overdueDays * 5.0:F2}");
                Console.ResetColor();
            }
            else
            {
                Success("Book returned on time. No fine.");
            }
        }

        private void ViewActiveBorrows()
        {
            Header("ACTIVE BORROWS");
            var active = _lib.GetActiveBorrows().ToList();
            if (!active.Any()) { Console.WriteLine("  No active borrows."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"#",-4} {"Book",-25} {"Member",-18} {"Borrowed",-13} {"Due",-13} {"Overdue?"}");
            Console.WriteLine("  " + new string('─', 80));
            Console.ResetColor();

            foreach (var r in active)
            {
                Console.ForegroundColor = r.IsOverdue ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine($"  {r.Id,-4} {_lib.BookTitle(r.BookId),-25} {_lib.MemberName(r.MemberId),-18} " +
                                  $"{r.BorrowedOn:dd/MM/yy}     {r.DueDate:dd/MM/yy}     " +
                                  $"{(r.IsOverdue ? $"YES ({r.OverdueDays}d)" : "No")}");
                Console.ResetColor();
            }
        }

        private void ViewOverdue()
        {
            Header("OVERDUE BOOKS");
            var overdue = _lib.GetOverdueRecords().ToList();
            if (!overdue.Any()) { Success("No overdue books!"); return; }

            foreach (var r in overdue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  Book   : {_lib.BookTitle(r.BookId)}");
                Console.WriteLine($"  Member : {_lib.MemberName(r.MemberId)}");
                Console.WriteLine($"  Due    : {r.DueDate:dd MMM yyyy}  ({r.OverdueDays} days overdue)");
                Console.WriteLine($"  Fine   : ₹{r.Fine:F2}");
                Console.ResetColor();
                Console.WriteLine("  " + new string('─', 40));
            }
        }

        private void ViewMemberHistory()
        {
            Header("MEMBER BORROW HISTORY");
            ViewAllMembers();
            Console.WriteLine();
            int memberId = ReadInt("Member ID");
            _lib.GetMember(memberId); // validates existence

            var history = _lib.GetMemberHistory(memberId).ToList();
            if (!history.Any()) { Console.WriteLine("  No borrow history for this member."); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  {"Book",-25} {"Borrowed",-13} {"Due",-13} {"Returned",-13} {"Status"}");
            Console.WriteLine("  " + new string('─', 75));
            Console.ResetColor();

            foreach (var r in history)
            {
                string status   = r.IsReturned ? "Returned" : (r.IsOverdue ? "OVERDUE" : "Active");
                string returned = r.ReturnedOn.HasValue ? r.ReturnedOn.Value.ToString("dd/MM/yy") : "—";
                Console.ForegroundColor = r.IsOverdue ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine($"  {_lib.BookTitle(r.BookId),-25} {r.BorrowedOn:dd/MM/yy}     " +
                                  $"{r.DueDate:dd/MM/yy}     {returned,-13} {status}");
                Console.ResetColor();
            }
        }

        // ── HELPERS ──────────────────────────────────────────
        private void SeedData()
        {
            _lib.AddBook("Clean Code",                    "Robert C. Martin", "Programming");
            _lib.AddBook("The Pragmatic Programmer",      "Andrew Hunt",      "Programming");
            _lib.AddBook("Design Patterns",               "Gang of Four",     "Architecture");
            _lib.AddBook("C# in Depth",                  "Jon Skeet",        "Programming");
            _lib.AddBook("Atomic Habits",                 "James Clear",      "Self-Help");
            _lib.AddBook("The Alchemist",                 "Paulo Coelho",     "Fiction");

            _lib.AddMember("Aisha Sharma", "aisha@example.com",  "9876543210");
            _lib.AddMember("Rohan Mehta",  "rohan@example.com",  "9123456780");
            _lib.AddMember("Priya Patil",  "priya@example.com",  "9001234567");

            // Pre-borrow one book so borrow/return is immediately demo-able
            _lib.BorrowBook(1, 1, 14);
        }

        private string Prompt(string label) { Console.Write($"  {label}: "); return Console.ReadLine()?.Trim() ?? ""; }
        private int ReadInt(string label)
        {
            while (true) { Console.Write($"  {label}: "); if (int.TryParse(Console.ReadLine(), out int v)) return v; Warn("Enter a valid number."); }
        }
        private void Header(string t)  { Console.ForegroundColor = ConsoleColor.Green;  Console.WriteLine($"  ── {t} ──"); Console.ResetColor(); }
        private void Success(string m) { Console.ForegroundColor = ConsoleColor.Green;  Console.WriteLine("  ✔ " + m); Console.ResetColor(); }
        private void Warn(string m)    { Console.ForegroundColor = ConsoleColor.Red;    Console.WriteLine("  ✘ " + m); Console.ResetColor(); }
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