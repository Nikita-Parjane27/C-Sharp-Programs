using System;
using System.IO;
using System.Collections.Generic;

class FileCRUD
{
    static string filePath = "records.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- File-based CRUD ---");
            Console.WriteLine("1. Create Record");
            Console.WriteLine("2. Read All Records");
            Console.WriteLine("3. Update Record");
            Console.WriteLine("4. Delete Record");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateRecord(); break;
                case 2: ReadRecords(); break;
                case 3: UpdateRecord(); break;
                case 4: DeleteRecord(); break;
                case 5: return;
            }
        }
    }

    static void CreateRecord()
    {
        Console.Write("Enter record: ");
        string record = Console.ReadLine();
        File.AppendAllText(filePath, record + Environment.NewLine);
        Console.WriteLine("Record saved!");
    }

    static void ReadRecords()
    {
        if (!File.Exists(filePath)) { Console.WriteLine("No records found."); return; }
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
            Console.WriteLine($"{i + 1}. {lines[i]}");
    }

    static void UpdateRecord()
    {
        if (!File.Exists(filePath)) { Console.WriteLine("No records."); return; }
        List<string> lines = new List<string>(File.ReadAllLines(filePath));
        ReadRecords();
        Console.Write("Enter line number to update: ");
        int lineNo = int.Parse(Console.ReadLine()) - 1;
        if (lineNo < 0 || lineNo >= lines.Count) { Console.WriteLine("Invalid!"); return; }
        Console.Write("New value: ");
        lines[lineNo] = Console.ReadLine();
        File.WriteAllLines(filePath, lines);
        Console.WriteLine("Record updated!");
    }

    static void DeleteRecord()
    {
        if (!File.Exists(filePath)) { Console.WriteLine("No records."); return; }
        List<string> lines = new List<string>(File.ReadAllLines(filePath));
        ReadRecords();
        Console.Write("Enter line number to delete: ");
        int lineNo = int.Parse(Console.ReadLine()) - 1;
        if (lineNo < 0 || lineNo >= lines.Count) { Console.WriteLine("Invalid!"); return; }
        lines.RemoveAt(lineNo);
        File.WriteAllLines(filePath, lines);
        Console.WriteLine("Record deleted!");
    }
}