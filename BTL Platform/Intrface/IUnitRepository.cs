using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUnitRepository
    {
        List<Unit> GetUnits();
        Unit GetUnit(string id);

        void Insert(Unit unit);
        void Update(string id, Unit unit);
        void Delete(string id);
        void Save();
    }
}
