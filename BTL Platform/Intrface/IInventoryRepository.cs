using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IInventoryRepository
    {
        List<Inventory> GetInventorys();
        Inventory GetInventory(long id);

        void Insert(Inventory inventory);
        void Update(long id, Inventory inventory);
        void Delete(long id);
        void Save();
    }
}
