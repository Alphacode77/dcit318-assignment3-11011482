using System;

namespace InventoryRecCAP
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath = "inventory_data.json")
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void AddItem(InventoryItem item)
        {
            _logger.Add(item);
        }

        public void SeedSampleData()
        {
            var items = new[]
            {
                new InventoryItem(1, "Laptop", 15, DateTime.Now.AddDays(-30)),
                new InventoryItem(2, "Mouse", 50, DateTime.Now.AddDays(-25)),
                new InventoryItem(3, "Keyboard", 25, DateTime.Now.AddDays(-20)),
                new InventoryItem(4, "Monitor", 10, DateTime.Now.AddDays(-15)),
                new InventoryItem(5, "Headphones", 30, DateTime.Now.AddDays(-10))
            };
            foreach (var item in items)
            {
                _logger.Add(item);
            }
        }

        public void SaveData()
        {
            try
            {
                _logger.SaveToFile();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to save inventory data", ex);
            }
        }

        public void LoadData()
        {
            try
            {
                _logger.LoadFromFile();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load inventory data", ex);
            }
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("No inventory items found.");
                return;
            }
            Console.WriteLine($"Inventory Items ({items.Count} total):");
            Console.WriteLine("=====================================");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine($"Date Added: {item.DateAdded:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine("-------------------------------------");
            }
        }

        public void ClearMemory()
        {
            _logger.Clear();
        }

        public int GetItemCount()
        {
            return _logger.Count;
        }
    }
}
