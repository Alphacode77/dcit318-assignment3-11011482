# Healthcare System Management

A C# console application that manages patient records and prescriptions using collections and generics.

## Features

- Add patients interactively from the console
- Add prescriptions for existing patients
- List all patients
- View prescriptions for a specific patient
- Generic repository pattern for data storage (in-memory)

## Project Structure

```
HealthcareSys/
├── Program.cs              # Application entry point with interactive menu
├── Repository.cs           # Generic repository implementation
├── Patient.cs              # Patient entity class
├── Prescription.cs         # Prescription entity class
├── HealthSystemApp.cs      # Application logic and data operations
└── HealthcareSystem.csproj # Project file
```

## How to Run

1. Navigate to the HealthcareSys directory
2. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

## Interactive Menu

- 1: Add patient (enter ID, name, age, gender)
- 2: List all patients
- 3: Add prescription (enter prescription ID, patient ID, medication, date)
- 4: View prescriptions for a patient
- 5: Exit

Notes:

- Dates accept yyyy-MM-dd format; leaving blank uses today.
- Patient IDs and prescription IDs must be unique.
