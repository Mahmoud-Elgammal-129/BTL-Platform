using Azure.Core;
using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        BTLContext bTLContext;
        public InventoryRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                Inventory inventoryToDelete = GetInventory(id);
                if (inventoryToDelete != null)
                {
                    inventoryToDelete.IsDeleted = true;
                    bTLContext.Inventories.Update(inventoryToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error deleting inventory: {ex.Message}");
            }
        }

        public Inventory GetInventory(string id)
        {
            try
            {
                Inventory inventory = bTLContext.Inventories.FirstOrDefault(a => a.InventoryId == id && a.IsDeleted == false);
                return inventory;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error getting inventory: {ex.Message}");
                return null;
            }
        }

        public List<Inventory> GetInventorys()
        {
            try
            {
                var inventory = bTLContext.Inventories.Where(m => m.IsDeleted == false).ToList();
                return inventory;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error getting inventories: {ex.Message}");
                return null;
            }
        }

        public void Insert(Inventory inventory)
        {
            try
            {
                bTLContext.Inventories.Add(inventory);
                bTLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error inserting inventory: {ex.Message}");
            }
        }

        public void Save()
        {
            try
            {
                bTLContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error saving changes: {ex.Message}");
            }
        }

        public void Update(string id, Inventory inventory)
        {
            try
            {
                Inventory Oldinventory = GetInventory(id);

                Oldinventory.ItemName = inventory.ItemName;
                Oldinventory.Count = inventory.Count;
                Oldinventory.Description = inventory.Description;
                Oldinventory.Status = inventory.Status;
                bTLContext.Inventories.Update(Oldinventory);
                Save();
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error updating inventory: {ex.Message}");
            }
        }

    }
}
