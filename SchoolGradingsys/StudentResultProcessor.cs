using SchoolGradingsys.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingsys
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();
            int lineNumber = 0;

            using (var reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    line = line.Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    var fields = line.Split(',');
                    
                    if (fields.Length != 3)
                    {
                        throw new IncompleteRecordException($"Line {lineNumber}: Expected 3 fields, found {fields.Length}. Line: {line}");
                    }

                    if (!int.TryParse(fields[0].Trim(), out int id))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Student ID '{fields[0]}' cannot be converted to integer. Line: {line}");
                    }

                    string fullName = fields[1].Trim();
                    if (string.IsNullOrEmpty(fullName))
                    {
                        throw new IncompleteRecordException($"Line {lineNumber}: Full name is missing. Line: {line}");
                    }

                    if (!int.TryParse(fields[2].Trim(), out int score))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score '{fields[2]}' cannot be converted to integer. Line: {line}");
                    }

                    if (score < 0 || score > 100)
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score {score} is out of valid range (0-100). Line: {line}");
                    }

                    students.Add(new Student(id, fullName, score));
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("STUDENT GRADE REPORT");
                writer.WriteLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine($"Total Students: {students.Count}");
                writer.WriteLine();

                foreach (var student in students)
                {
                    string grade = student.GetGrade();
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {grade}");
                }

                writer.WriteLine();
                writer.WriteLine("GRADE SUMMARY");
                var gradeCounts = new Dictionary<string, int>();
                foreach (var student in students)
                {
                    string grade = student.GetGrade();
                    if (gradeCounts.ContainsKey(grade))
                        gradeCounts[grade]++;
                    else
                        gradeCounts[grade] = 1;
                }

                foreach (var grade in new[] { "A", "B", "C", "D", "F" })
                {
                    int count = gradeCounts.ContainsKey(grade) ? gradeCounts[grade] : 0;
                    writer.WriteLine($"Grade {grade}: {count} students");
                }
            }
        }
    }
}
