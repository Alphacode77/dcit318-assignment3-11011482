# Healthcare System Implementation Summary

## Overview

This C# console application demonstrates a healthcare system that manages patient records and prescriptions using Collections and Generics. The system showcases type safety, scalability, and reusability through proper use of C# generics and collections.

## Implementation Details

### 1. Generic Repository Pattern (`Repository<T>`)

**Location**: `Repository.cs`

**Key Features**:

- **Generic Class**: `Repository<T>` can handle any entity type
- **Type Safety**: Ensures compile-time type checking
- **Scalability**: Reusable for any entity type without code duplication

**Methods Implemented**:

- `void Add(T item)` - Adds items to the repository
- `List<T> GetAll()` - Returns all items (returns a copy for safety)
- `T? GetById(Func<T, bool> predicate)` - Returns first match or null
- `bool Remove(Func<T, bool> predicate)` - Removes items by condition

**Collections Used**:

- `List<T> items` - Internal storage using generic List

### 2. Entity Classes

#### Patient Class (`Patient.cs`)

**Fields**:

- `int Id`
- `string Name`
- `int Age`
- `string Gender`

**Constructor**: Initializes all fields
**Override**: `ToString()` for readable output

#### Prescription Class (`Prescription.cs`)

**Fields**:

- `int Id`
- `int PatientId`
- `string MedicationName`
- `DateTime DateIssued`

**Constructor**: Initializes all fields
**Override**: `ToString()` for readable output

### 3. Collections Management

#### Dictionary Implementation

**Location**: `HealthSystemApp.cs`

**Structure**: `Dictionary<int, List<Prescription>> _prescriptionMap`

- **Key**: Patient ID (int)
- **Value**: List of prescriptions for that patient

**Purpose**: Efficient O(1) lookup of prescriptions by patient ID

#### Grouping Logic

**Method**: `BuildPrescriptionMap()`

- Loops through all prescriptions from repository
- Groups by `PatientId`
- Populates the dictionary for efficient access

### 4. Main Application Class (`HealthSystemApp`)

**Fields**:

- `Repository<Patient> _patientRepo` - Generic repository for patients
- `Repository<Prescription> _prescriptionRepo` - Generic repository for prescriptions
- `Dictionary<int, List<Prescription>> _prescriptionMap` - Patient-prescription mapping

**Key Methods**:

#### `SeedData()`

- Adds 3 Patient objects to patient repository
- Adds 5 Prescription objects to prescription repository
- Demonstrates repository usage with different entity types

#### `BuildPrescriptionMap()`

- Groups prescriptions by PatientId
- Populates the dictionary for efficient lookup
- Demonstrates collection operations and LINQ usage

#### `GetPrescriptionsByPatientId(int patientId)`

- Retrieves prescriptions from the dictionary
- Returns `List<Prescription>` for the specified patient
- Handles cases where patient has no prescriptions

#### `PrintAllPatients()`

- Uses repository to fetch all patients
- Demonstrates generic repository functionality

#### `PrintPrescriptionsForPatient(int patientId)`

- Shows prescriptions for a specific patient
- Uses both repository and dictionary for data access

### 5. Application Flow (`Program.cs`)

**Main Method Implementation**:

1. **Instantiate** `HealthSystemApp`
2. **Call** `SeedData()` - Populate with sample data
3. **Call** `BuildPrescriptionMap()` - Build patient-prescription relationships
4. **Print** all patients using repository
5. **Display** prescriptions for each patient using the map

## Generics Usage Examples

### 1. Generic Repository

```csharp
Repository<Patient> _patientRepo = new Repository<Patient>();
Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
```

### 2. Generic Collections

```csharp
List<T> items; // In Repository<T>
Dictionary<int, List<Prescription>> _prescriptionMap;
```

### 3. Generic Methods

```csharp
T? GetById(Func<T, bool> predicate);
bool Remove(Func<T, bool> predicate);
```

## Collections Usage Examples

### 1. List<T>

- Storage in repositories
- Return copies for safety
- LINQ operations for filtering

### 2. Dictionary<K,V>

- Patient-prescription mapping
- O(1) lookup performance
- Efficient grouping and access

### 3. LINQ Operations

- `FirstOrDefault()` for single item retrieval
- `Where()` for filtering
- `ToList()` for collection conversion

## Type Safety Features

1. **Generic Constraints**: Repository works with any type
2. **Compile-time Checking**: Type mismatches caught at compile time
3. **Null Safety**: Proper null checking and nullable reference types
4. **Type-safe Collections**: All collections are strongly typed

## Scalability Features

1. **Generic Repository**: Can handle any entity type
2. **Dictionary Lookup**: Efficient patient-prescription access
3. **Separation of Concerns**: Each class has a single responsibility
4. **Extensible Design**: Easy to add new entity types

## Reusability Features

1. **Repository Pattern**: Reusable for any entity type
2. **Generic Methods**: Work with any type that meets constraints
3. **Modular Design**: Components can be reused independently
4. **Clean Interfaces**: Well-defined method signatures

## Sample Output

The application demonstrates:

- **3 Patients** with different demographics
- **5 Prescriptions** distributed across patients
- **Efficient Lookup** using dictionary mapping
- **Type-safe Operations** throughout the system

## Key Benefits Demonstrated

1. **Type Safety**: Compile-time type checking prevents runtime errors
2. **Scalability**: Generic repository can handle any entity type
3. **Reusability**: Repository pattern can be used for any domain
4. **Performance**: Dictionary provides O(1) lookup for prescriptions
5. **Maintainability**: Clean separation of concerns and modular design

This implementation successfully demonstrates all required C# features including generics, collections, LINQ, and object-oriented design principles while providing a practical healthcare management system.

