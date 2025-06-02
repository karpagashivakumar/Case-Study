using System;
using System.Collections.Generic;

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        // Adding initial students
        students.Add(new Student { ID = 1, Name = "Alice" });
        students.Add(new Student { ID = 2, Name = "Bob" });
        students.Add(new Student { ID = 3, Name = "Charlie" });

        // Display all students
        Console.WriteLine("All Students:");
        foreach (Student student in students)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
        }

        // Search student by name
        Console.Write("\nEnter name to search: ");
        string searchName = Console.ReadLine();

        Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        if (foundStudent != null)
        {
            Console.WriteLine($"Found: ID={foundStudent.ID}, Name={foundStudent.Name}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Remove student by name
        Console.Write("\nEnter name to remove: ");
        string removeName = Console.ReadLine();

        Student studentToRemove = students.Find(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine("Student removed.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Updated list
        Console.WriteLine("\nUpdated List of Students:");
        foreach (Student student in students)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
        }

        // Count total students
        Console.WriteLine($"\nTotal number of students: {students.Count}");
    }
}