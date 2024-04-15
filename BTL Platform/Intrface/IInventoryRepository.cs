using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IInventoryRepository
    {
        List<Inventory> GetInventorys();
        Inventory GetInventory(string id);

        void Insert(Inventory inventory);
        void Update(string id, Inventory inventory);
        void Delete(string id);
        void Save();
    }
}
