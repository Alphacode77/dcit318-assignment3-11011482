# Inventory Records CAP System

A C# application demonstrating records, generics, and JSON persistence with an interactive console.

## Features

- Add inventory items interactively
- List items
- Save to JSON file and load from file
- Clear in-memory data

## Project Structure

```
InventoryRecCAP/
├── Interfaces/
│   └── IInventoryEntity.cs
├── InventoryItem.cs
├── InventoryLogger.cs
├── InventoryApp.cs
├── Program.cs
└── README.md
```

## How to Run

```bash
cd InventoryRecCAP
dotnet run
```

## Interactive Menu

- 1: Add item
- 2: List items
- 3: Save to file
- 4: Load from file
- 5: Clear memory
- 6: Exit

Notes:

- Items are stored in-memory until saved.
- Default file path is `inventory_data.json` (configurable via constructor in `InventoryApp`).
