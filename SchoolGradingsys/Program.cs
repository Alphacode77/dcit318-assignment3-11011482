using SchoolGradingsys;
using SchoolGradingsys.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingsys
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var processor = new StudentResultProcessor();

            while (true)
            {
                Console.WriteLine("School Grading System");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. List students");
                Console.WriteLine("3. Generate grade report to file");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    try
                    {
                        Console.Write("Enter student ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                        Console.Write("Enter full name (Surname First): ");
                        var name = (Console.ReadLine() ?? string.Empty).Trim();
                        Console.Write("Enter score (0-100): ");
                        if (!int.TryParse(Console.ReadLine(), out int score) || score < 0 || score > 100)
                        { Console.WriteLine("Invalid score.\n"); continue; }
                        if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Full name is required.\n"); continue; }
                        if (students.Exists(s => s.Id == id)) { Console.WriteLine($"Student with ID {id} already exists.\n"); continue; }
                        students.Add(new Student(id, name, score));
                        Console.WriteLine("Student added.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding student: {ex.Message}\n");
                    }
                }
                else if (input == "2")
                {
                    if (students.Count == 0) { Console.WriteLine("No students added yet.\n"); continue; }
                    Console.WriteLine("Students:");
                    foreach (var s in students)
                    {
                        Console.WriteLine($"{s.FullName} (ID: {s.Id}): Score = {s.Score}, Grade = {s.GetGrade()}");
                    }
                    Console.WriteLine();
                }
                else if (input == "3")
                {
                    if (students.Count == 0) { Console.WriteLine("No students to report.\n"); continue; }
                    Console.Write("Enter output file path (default: grade_report.txt): ");
                    var path = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(path)) path = "grade_report.txt";
                    try
                    {
                        processor.WriteReportToFile(students, path);
                        Console.WriteLine($"Report written to {path}.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to write report: {ex.Message}\n");
                    }
                }
                else if (input == "4")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.\n");
                }
            }
        }
    }
}
