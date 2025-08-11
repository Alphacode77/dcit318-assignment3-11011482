using WarehouseInventory.Products;
using WarehouseInventory.Repository;
using WarehouseInventory.Exceptions;
using System;

namespace WarehouseInventory
{
    public class WarehouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics;
        private InventoryRepository<GroceryItem> _groceries;

        public WarehouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            try
            {
                var items = repo.GetAllItems();
                if (items.Count == 0)
                {
                    Console.WriteLine("No items found in this inventory.");
                    return;
                }
                Console.WriteLine($"\n--- {typeof(T).Name} Inventory ({items.Count} items) ---");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error printing items: {ex.Message}");
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Successfully increased stock for item {id} by {quantity}. New quantity: {item.Quantity + quantity}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.RemoveItem(id);
                Console.WriteLine($"Successfully removed item: {item.Name} (ID: {id})");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public InventoryRepository<ElectronicItem> Electronics => _electronics;
        public InventoryRepository<GroceryItem> Groceries => _groceries;
    }
}
