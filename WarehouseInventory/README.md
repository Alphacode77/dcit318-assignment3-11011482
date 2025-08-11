# Warehouse Inventory Management System

A C# console application using collections, generics, and exceptions to manage inventory.

## Features

- Manage two categories: Electronics and Groceries
- Add, list, update quantity, and remove items
- Generic repository with custom exceptions

## Project Structure

```
WarehouseInventory/
├── IInventoryItem.cs
├── Products/
│   ├── ElectronicItem.cs
│   └── GroceryItem.cs
├── Exceptions/
│   ├── DuplicateItemException.cs
│   ├── ItemNotFoundException.cs
│   └── InvalidQuantityException.cs
├── Repository/
│   └── InventoryRepository.cs
├── WarehouseManager.cs
├── Program.cs
└── README.md
```

## How to Run

```bash
cd WarehouseInventory
dotnet run
```

## Interactive Menu

- 1: Add item (choose category)
- 2: List items (choose category)
- 3: Update quantity (choose category, item ID)
- 4: Remove item (choose category, item ID)
- 5: Exit

Notes:

- Quantities must be non-negative integers.
- Electronics require brand and warranty months; Groceries require an expiry date (yyyy-MM-dd).
