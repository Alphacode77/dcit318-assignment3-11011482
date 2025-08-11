using System;

namespace InventoryRecCAP
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new InventoryApp();

            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. List items");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Load from file");
                Console.WriteLine("5. Clear memory");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    try
                    {
                        Console.Write("Enter ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                        Console.Write("Enter name: ");
                        var name = (Console.ReadLine() ?? string.Empty).Trim();
                        Console.Write("Enter quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int qty) || qty < 0) { Console.WriteLine("Invalid quantity.\n"); continue; }
                        var item = new InventoryItem(id, name, qty, DateTime.Now);
                        app.AddItem(item);
                        Console.WriteLine("Item added.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to add item: {ex.Message}\n");
                    }
                }
                else if (input == "2")
                {
                    app.PrintAllItems();
                    Console.WriteLine();
                }
                else if (input == "3")
                {
                    try { app.SaveData(); Console.WriteLine("Saved.\n"); }
                    catch (Exception ex) { Console.WriteLine($"Save failed: {ex.Message}\n"); }
                }
                else if (input == "4")
                {
                    try { app.LoadData(); Console.WriteLine("Loaded.\n"); }
                    catch (Exception ex) { Console.WriteLine($"Load failed: {ex.Message}\n"); }
                }
                else if (input == "5")
                {
                    app.ClearMemory();
                    Console.WriteLine("Memory cleared.\n");
                }
                else if (input == "6")
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
