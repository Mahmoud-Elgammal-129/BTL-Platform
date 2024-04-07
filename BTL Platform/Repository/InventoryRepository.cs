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
        public void Delete(long id)
        {
            Inventory inventoryToDelete = GetInventory(id);
            if (inventoryToDelete != null)
            {
                inventoryToDelete.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public Inventory GetInventory(long id)
        {
            Inventory inventory = bTLContext.Inventories.FirstOrDefault(a => a.InventoryId == id &&a.IsDeleted==false);
            return inventory;
        }

        public List<Inventory> GetInventorys()
        {
            var inventory = bTLContext.Inventories.Where(m=>m.IsDeleted==false).ToList();
            return inventory;
        }

        public void Insert(Inventory inventory)
        {
            bTLContext.Inventories.Add(inventory);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, Inventory inventory)
        {
            Inventory Oldinventory = GetInventory(id);

            Oldinventory.ItemName = inventory.ItemName;
            Oldinventory.count = inventory.count;
            Oldinventory.Description = inventory.Description;
            Oldinventory.Status = inventory.Status;
            bTLContext.Inventories.Update(Oldinventory);
            Save();
        }
    }
}
