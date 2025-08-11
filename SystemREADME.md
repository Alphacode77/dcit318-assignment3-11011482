# Multiple System Implementations

A comprehensive collection of C# applications demonstrating various programming concepts including exception handling, file I/O, records, generics, and system design patterns.

## Project Overview

This repository contains four distinct C# applications, each showcasing different aspects of software development:

1. **[School Grading System](#system-1-school-grading-system)** - Interactive exception handling and file operations
2. **[Healthcare System](#system-2-healthcare-system)** - Interactive healthcare management with generics
3. **[Warehouse Inventory System](#system-3-warehouse-inventory-system)** - Interactive inventory management with generics and exceptions
4. **[Inventory Records CAP System](#system-4-inventory-records-cap-system)** - Interactive records, generics, and data persistence

## Quick Navigation

- [School Grading System](#system-1-school-grading-system)
- [Healthcare System](#system-2-healthcare-system)
- [Warehouse Inventory System](#system-3-warehouse-inventory-system)
- [Inventory Records CAP System](#system-4-inventory-records-cap-system)
- [Common Technical Features](#common-technical-features)
- [Getting Started](#getting-started)

## System 1: School Grading System

### Purpose

An interactive console application that allows users to add students, manage scores, validate data, assign grades, and generate comprehensive reports with robust exception handling.

### Key Features

- **Interactive Student Management**: Add students through console input
- **Student Class**: Manages student data with ID, name, and score
- **Grade Calculation**: Automatic letter grade assignment (A-F scale)
- **Custom Exceptions**: InvalidScoreFormatException and IncompleteRecordException
- **File Processing**: Generates formatted reports to files
- **Data Validation**: Comprehensive input validation and error handling

### Technical Implementation

- **Interactive Console**: Menu-driven user interface
- **Exception Handling**: Custom exception classes with meaningful messages
- **Data Validation**: Field count, data type, and range validation
- **Collections**: List<Student> for data management

### File Structure

```
SchoolGradingsys/
├── Student.cs                           # Student entity class
├── Exceptions/
│   ├── InvalidScoreFormatException.cs  # Custom exception for invalid scores
│   └── IncompleteRecordException.cs    # Custom exception for missing fields
├── StudentResultProcessor.cs            # Main processing logic
├── Program.cs                           # Interactive application entry point
├── students_input.txt                   # Sample input file
└── SchoolGradingsys.csproj             # Project file
```

### Usage

```bash
cd SchoolGradingsys
dotnet run
```

### Interactive Menu

- **Add Student**: Enter ID, full name (Surname First), and score (0-100)
- **List Students**: View all added students with computed grades
- **Generate Report**: Write grade report to a file
- **Exit**: Close the application

### Grade Scale

- Score 80-100: Grade A
- Score 70-79: Grade B
- Score 60-69: Grade C
- Score 50-59: Grade D
- Score below 50: Grade F

## System 2: Healthcare System

### Purpose

An interactive healthcare management system demonstrating generics, collections, and the repository pattern for managing patients and prescriptions.

### Key Features

- **Interactive Patient Management**: Add patients through console input
- **Interactive Prescription System**: Add prescriptions for existing patients
- **Generic Repository Pattern**: Type-safe data access abstraction
- **Collections Management**: Dictionary-based prescription mapping
- **Patient-Prescription Relationships**: Efficient lookup and grouping

### Technical Implementation

- **Generic Repository<T>**: Type-safe storage and retrieval operations
- **Dictionary<int, List<Prescription>>**: Efficient patient-prescription mapping
- **LINQ Operations**: Filtering and grouping prescriptions
- **Interactive Console**: Menu-driven user interface

### File Structure

```
HealthcareSys/
├── Patient.cs                           # Patient entity
├── Prescription.cs                      # Prescription entity
├── Repository.cs                        # Generic repository implementation
├── HealthSystemApp.cs                   # Main application logic
├── Program.cs                           # Interactive entry point
└── HealthcareSystem.csproj              # Project file
```

### Usage

```bash
cd HealthcareSys
dotnet run
```

### Interactive Menu

- **Add Patient**: Enter ID, name, age, and gender
- **List Patients**: View all registered patients
- **Add Prescription**: Enter prescription details for existing patients
- **View Prescriptions**: Display prescriptions for a specific patient
- **Exit**: Close the application

## System 3: Warehouse Inventory System

### Purpose

An interactive inventory management system demonstrating generics, collections, custom exceptions, and interface-based design for managing different types of inventory items.

### Key Features

- **Interactive Item Management**: Add, update, and remove inventory items
- **Dual Category Support**: Electronics and Groceries with different properties
- **Generic Repository**: Type-safe inventory management
- **Custom Exceptions**: Comprehensive error handling
- **Interface Design**: Marker interface pattern implementation

### Technical Implementation

- **Generic Repository<T>**: Type-safe repository with constraints
- **Custom Exceptions**: DuplicateItemException, ItemNotFoundException, InvalidQuantityException
- **Dictionary Storage**: Efficient item lookup and management
- **Interactive Console**: Menu-driven user interface

### File Structure

```
WarehouseInventory/
├── IInventoryItem.cs                    # Marker interface
├── Products/
│   ├── ElectronicItem.cs                # Electronic product implementation
│   └── GroceryItem.cs                   # Grocery product implementation
├── Exceptions/
│   ├── DuplicateItemException.cs        # Custom exception for duplicates
│   ├── ItemNotFoundException.cs          # Custom exception for missing items
│   └── InvalidQuantityException.cs      # Custom exception for invalid quantities
├── Repository/
│   └── InventoryRepository.cs           # Generic repository implementation
├── WarehouseManager.cs                   # Main management class
├── Program.cs                            # Interactive entry point
└── WarehouseInventory.csproj             # Project file
```

### Usage

```bash
cd WarehouseInventory
dotnet run
```

### Interactive Menu

- **Add Item**: Choose category (Electronics/Groceries) and enter item details
- **List Items**: Display all items in a selected category
- **Update Quantity**: Modify item quantities
- **Remove Item**: Delete items from inventory
- **Exit**: Close the application

### Item Types

- **Electronics**: ID, name, quantity, brand, warranty months
- **Groceries**: ID, name, quantity, expiry date

## System 4: Inventory Records CAP System

### Purpose

An interactive inventory management system demonstrating modern C# features including records for immutable data representation, generics for reusable operations, and JSON persistence.

### Key Features

- **Interactive Item Management**: Add inventory items through console
- **Immutable Records**: C# records with positional syntax
- **Generic Logger**: Type-safe inventory management
- **Marker Interface**: Contract enforcement through interfaces
- **JSON Persistence**: Human-readable data storage and recovery

### Technical Implementation

- **C# Records**: Immutable data structures with value semantics
- **Generics**: Type-safe, reusable code patterns
- **File Operations**: JSON serialization with proper error handling
- **Resource Management**: Using statements for proper disposal

### File Structure

```
InventoryRecCAP/
├── Interfaces/
│   └── IInventoryEntity.cs           # Marker interface
├── InventoryItem.cs                   # Immutable record
├── InventoryLogger.cs                 # Generic logger with file operations
├── InventoryApp.cs                    # Integration layer
├── Program.cs                         # Interactive main application
├── InventoryRecCAP.csproj             # Project file
└── README.md                          # Documentation
```

### Usage

```bash
cd InventoryRecCAP
dotnet run
```

### Interactive Menu

- **Add Item**: Enter ID, name, and quantity
- **List Items**: Display all inventory items
- **Save to File**: Persist data to JSON file
- **Load from File**: Recover data from persistent storage
- **Clear Memory**: Clear in-memory data
- **Exit**: Close the application

## Common Technical Features

### .NET Version

All projects target .NET 8.0 for the latest C# features and performance improvements.

### Exception Handling

- **Custom Exceptions**: Application-specific error types
- **Graceful Degradation**: User-friendly error messages
- **Comprehensive Coverage**: File I/O, data validation, and business logic errors

### File Operations

- **StreamReader/StreamWriter**: Proper resource disposal with using statements
- **JSON Serialization**: Human-readable data formats
- **Error Handling**: Robust file I/O exception management

### Code Organization

- **Separation of Concerns**: Clear separation between data, logic, and presentation
- **Interface Design**: Contract enforcement and abstraction
- **Modular Architecture**: Reusable components and clean dependencies

## Learning Objectives

These systems collectively demonstrate:

- **Object-Oriented Programming**: Classes, inheritance, and polymorphism
- **Exception Handling**: Custom exceptions and error management
- **File I/O Operations**: Reading, writing, and data persistence
- **Data Validation**: Input validation and error checking
- **Generic Programming**: Type-safe, reusable code patterns
- **Modern C# Features**: Records, pattern matching, and nullable reference types
- **Resource Management**: Proper disposal and memory management
- **System Design**: Architecture patterns and best practices
- **Interactive Design**: User-friendly console interfaces

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022, VS Code, or any C# IDE

### Building and Running

```bash
# Build all projects
dotnet build

# Run specific systems
cd SchoolGradingsys && dotnet run
cd HealthcareSys && dotnet run
cd WarehouseInventory && dotnet run
cd InventoryRecCAP && dotnet run
```

### Testing

Each system includes interactive menus and can be run independently to demonstrate its functionality. All systems now support user input for data management rather than relying solely on pre-seeded data.

## Project Structure

```
dcit318-assignment3-11011482/
├── SchoolGradingsys/                   # Interactive school grading system
├── HealthcareSys/                      # Interactive healthcare management system
├── WarehouseInventory/                 # Interactive warehouse inventory system
├── InventoryRecCAP/                    # Interactive inventory records system
└── README.md                           # This file
```

## Future Enhancements

### School Grading System

- Database integration for persistent storage
- Web interface for grade management
- Statistical analysis and reporting
- Grade curve adjustments

### Healthcare System

- Patient database integration
- Appointment scheduling
- Medical history tracking
- Prescription validation

### Warehouse Inventory System

- Database integration (SQL Server/SQLite)
- Web API endpoints
- Real-time updates with SignalR
- Advanced analytics and reporting

### Inventory Records CAP System

- Database integration (SQL Server/SQLite)
- Web API endpoints
- Real-time updates with SignalR
- Advanced analytics and reporting

## Contributing

This is an academic assignment demonstrating various C# programming concepts. The code is structured for learning purposes and can serve as a foundation for more complex applications.
