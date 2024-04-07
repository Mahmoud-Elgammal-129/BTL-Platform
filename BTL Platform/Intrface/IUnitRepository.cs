using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUnitRepository
    {
        List<Unit> GetUnits();
        Unit GetUnit(long id);

        void Insert(Unit unit);
        void Update(long id, Unit unit);
        void Delete(long id);
        void Save();
    }
}
