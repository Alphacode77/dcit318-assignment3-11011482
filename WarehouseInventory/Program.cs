using WarehouseInventory;
using WarehouseInventory.Products;
using WarehouseInventory.Exceptions;
using System;

namespace WarehouseInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new WarehouseManager();

            while (true)
            {
                Console.WriteLine("Warehouse Inventory Management System");
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. List items");
                Console.WriteLine("3. Update quantity");
                Console.WriteLine("4. Remove item");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    var repo = SelectRepo(manager);
                    if (repo == null) { Console.WriteLine("Invalid category.\n"); continue; }
                    Console.Write("Enter item ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                    Console.Write("Enter name: ");
                    var name = (Console.ReadLine() ?? string.Empty).Trim();
                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int qty) || qty < 0) { Console.WriteLine("Invalid quantity.\n"); continue; }

                    if (repo is Repository.InventoryRepository<ElectronicItem> er)
                    {
                        Console.Write("Enter brand: ");
                        var brand = (Console.ReadLine() ?? string.Empty).Trim();
                        Console.Write("Enter warranty months: ");
                        if (!int.TryParse(Console.ReadLine(), out int warranty) || warranty < 0) { Console.WriteLine("Invalid warranty.\n"); continue; }
                        try { er.AddItem(new ElectronicItem(id, name, qty, brand, warranty)); Console.WriteLine("Item added.\n"); }
                        catch (Exception ex) { Console.WriteLine($"Failed to add item: {ex.Message}\n"); }
                    }
                    else if (repo is Repository.InventoryRepository<GroceryItem> gr)
                    {
                        Console.Write("Enter expiry date (yyyy-MM-dd): ");
                        var dateStr = Console.ReadLine();
                        if (!DateTime.TryParse(dateStr, out DateTime expiry)) { Console.WriteLine("Invalid date.\n"); continue; }
                        try { gr.AddItem(new GroceryItem(id, name, qty, expiry)); Console.WriteLine("Item added.\n"); }
                        catch (Exception ex) { Console.WriteLine($"Failed to add item: {ex.Message}\n"); }
                    }
                }
                else if (input == "2")
                {
                    var repo = SelectRepo(manager);
                    if (repo == null) { Console.WriteLine("Invalid category.\n"); continue; }
                    if (repo is Repository.InventoryRepository<ElectronicItem> er) manager.PrintAllItems(er);
                    else if (repo is Repository.InventoryRepository<GroceryItem> gr) manager.PrintAllItems(gr);
                    Console.WriteLine();
                }
                else if (input == "3")
                {
                    var repo = SelectRepo(manager);
                    if (repo == null) { Console.WriteLine("Invalid category.\n"); continue; }
                    Console.Write("Enter item ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                    Console.Write("Enter new quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int qty) || qty < 0) { Console.WriteLine("Invalid quantity.\n"); continue; }
                    try
                    {
                        if (repo is Repository.InventoryRepository<ElectronicItem> er) er.UpdateQuantity(id, qty);
                        else if (repo is Repository.InventoryRepository<GroceryItem> gr) gr.UpdateQuantity(id, qty);
                        Console.WriteLine("Quantity updated.\n");
                    }
                    catch (Exception ex) { Console.WriteLine($"Failed to update: {ex.Message}\n"); }
                }
                else if (input == "4")
                {
                    var repo = SelectRepo(manager);
                    if (repo == null) { Console.WriteLine("Invalid category.\n"); continue; }
                    Console.Write("Enter item ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                    try
                    {
                        if (repo is Repository.InventoryRepository<ElectronicItem> er) manager.RemoveItemById(er, id);
                        else if (repo is Repository.InventoryRepository<GroceryItem> gr) manager.RemoveItemById(gr, id);
                        Console.WriteLine();
                    }
                    catch (Exception ex) { Console.WriteLine($"Failed to remove: {ex.Message}\n"); }
                }
                else if (input == "5")
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

        private static object? SelectRepo(WarehouseManager manager)
        {
            Console.WriteLine("Select category: 1) Electronics  2) Groceries");
            Console.Write("Enter choice: ");
            var c = Console.ReadLine();
            if (c == "1") return manager.Electronics;
            if (c == "2") return manager.Groceries;
            return null;
        }
    }
}
