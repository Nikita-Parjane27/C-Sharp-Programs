using System;
namespace JOIN_LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data for two collections
            var students = new[]
            {
                new { StudentId = 1, Name = "Alice" },
                new { StudentId = 2, Name = "Bob" },
                new { StudentId = 3, Name = "Charlie" }
            };

            var courses = new[]
            {
                new { CourseId = 101, StudentId = 1, CourseName = "Math" },
                new { CourseId = 102, StudentId = 2, CourseName = "Science" },
                new { CourseId = 103, StudentId = 1, CourseName = "History" }
            };

            // Perform a JOIN operation using LINQ
            var studentCourses = from student in students
                                 join course in courses on student.StudentId equals course.StudentId
                                 select new
                                 {
                                     StudentName = student.Name,
                                     CourseName = course.CourseName
                                 };

            // Display the results of the JOIN operation
            Console.WriteLine("Student Courses:");
            foreach (var sc in studentCourses)
            {
                Console.WriteLine($"{sc.StudentName} is enrolled in {sc.CourseName}");
            }
        }
    }
}