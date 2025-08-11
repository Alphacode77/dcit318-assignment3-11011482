# School Grading System

A C# console application that processes student scores and generates grade reports with proper validation and error handling.

## Features

- Add students interactively from the console (ID, full name, score)
- List all added students with computed grades
- Generate a grade report to a file
- Custom exceptions used internally for validation workflows

## Project Structure

```
SchoolGradingsys/
├── Student.cs                # Student entity class
├── Exceptions/               # Custom exceptions
│   ├── InvalidScoreFormatException.cs
│   └── IncompleteRecordException.cs
├── StudentResultProcessor.cs # Report writer
├── Program.cs                # Interactive console
├── SchoolGradingsys.csproj
└── README.md
```

## How to Run

```bash
cd SchoolGradingsys
dotnet run
```

## Interactive Menu

- 1: Add student
- 2: List students
- 3: Generate grade report to file
- 4: Exit

Notes:

- Scores must be between 0 and 100.
- Default report path is `grade_report.txt` if none is provided.
