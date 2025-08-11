using InventoryRecCAP.Interfaces;

namespace InventoryRecCAP
{
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
