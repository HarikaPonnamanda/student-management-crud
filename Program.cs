using System;
using System.Collections.Generic;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

class Program
{
    static List<Student> students = new List<Student>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Add Student");
           Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": AddStudent(); break;
                case "2": ViewStudents(); break;
                case "3": UpdateStudent(); break;
                case "4": DeleteStudent(); break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student marks: ");
        if (!int.TryParse(Console.ReadLine(), out int marks))
        {
            Console.WriteLine("Invalid marks. Operation cancelled.");
            return;
        }

        Student s = new Student()
        {
            Id = nextId++,
            Name = name,
            Marks = marks
        };

        students.Add(s);
        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n--- Student List ---");
        foreach (var s in students)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Marks: {s.Marks}");
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter student ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student s = students.Find(st => st.Id == id);

        if (s == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        Console.Write("Enter new name: ");
        s.Name = Console.ReadLine();

        Console.Write("Enter new marks: ");
        if (!int.TryParse(Console.ReadLine(), out int newMarks))
        {
            Console.WriteLine("Invalid marks. Update cancelled.");
            return;
        }

        s.Marks = newMarks;

        Console.WriteLine("Student updated successfully!");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Student s = students.Find(st => st.Id == id);

        if (s == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        students.Remove(s);
        Console.WriteLine("Student deleted successfully!");
    }
}
