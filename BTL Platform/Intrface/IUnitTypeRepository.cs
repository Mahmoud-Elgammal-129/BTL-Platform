using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IUnitTypeRepository
    {
        List<UnitType> GetUnitTypes();
        UnitType GetUnitType(string id);

        void Insert(UnitType unittype);
        void Update(string id, UnitType unittype);
        void Delete(string id);
        void Save();
    }
}
