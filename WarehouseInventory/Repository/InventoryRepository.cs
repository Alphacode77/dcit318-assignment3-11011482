using WarehouseInventory;
using WarehouseInventory.Exceptions;
using System.Collections.Generic;

namespace WarehouseInventory.Repository
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private Dictionary<int, T> _items;

        public InventoryRepository()
        {
            _items = new Dictionary<int, T>();
        }

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException($"Item with ID {item.Id} already exists in the inventory.");
            }
            _items.Add(item.Id, item);
        }

        public T GetItemById(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory.");
            }
            return _items[id];
        }

        public void RemoveItem(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory.");
            }
            _items.Remove(id);
        }

        public List<T> GetAllItems()
        {
            return new List<T>(_items.Values);
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException($"Quantity cannot be negative. Provided quantity: {newQuantity}");
            }
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory.");
            }
            var item = _items[id];
            item.Quantity = newQuantity;
        }

        public int GetItemCount()
        {
            return _items.Count;
        }
    }
}
