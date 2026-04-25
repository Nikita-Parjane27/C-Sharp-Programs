using System;
using System.Data.SqlClient;

class AdoNetCRUD
{
    static string connStr = "Server=.;Database=TestDB;Integrated Security=true;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- ADO.NET CRUD ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: InsertStudent(); break;
                case 2: ViewStudents(); break;
                case 3: UpdateStudent(); break;
                case 4: DeleteStudent(); break;
                case 5: return;
            }
        }
    }

    static void InsertStudent()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Age: "); int age = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "INSERT INTO Students (Name, Age) VALUES (@Name, @Age)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Student inserted!");
        }
    }

    static void ViewStudents()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("ID\tName\tAge");
            while (reader.Read())
                Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Age"]}");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter ID to update: "); int id = int.Parse(Console.ReadLine());
        Console.Write("New Name: "); string name = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Students SET Name=@Name WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Updated!");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter ID to delete: "); int id = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Deleted!");
        }
    }
}