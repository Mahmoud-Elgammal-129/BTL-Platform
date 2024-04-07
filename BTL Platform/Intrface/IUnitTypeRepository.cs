using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUnitTypeRepository
    {
        List<UnitType> GetUnitTypes();
        UnitType GetUnitType(long id);

        void Insert(UnitType unittype);
        void Update(long id, UnitType unittype);
        void Delete(long id);
        void Save();
    }
}
