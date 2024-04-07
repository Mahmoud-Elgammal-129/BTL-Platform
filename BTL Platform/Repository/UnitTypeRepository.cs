using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        BTLContext bTLContext;
        public UnitTypeRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(long id)
        {
             UnitType UnitTypeToDelete = GetUnitType(id);
            if (UnitTypeToDelete != null)
            {
                UnitTypeToDelete.IsDeleted = true;
                bTLContext.UnitTypes.Update(UnitTypeToDelete);
                
                Save(); // Save method should handle the changes
            }
        }

        public UnitType GetUnitType(long id)
        {
            UnitType unitType = bTLContext.UnitTypes.FirstOrDefault(a => a.UnitTypeId == id&& a.IsDeleted==false);
            return unitType;
        }

        public List<UnitType> GetUnitTypes()
        {
            var unitType = bTLContext.UnitTypes.Where(n => n.IsDeleted == false).ToList();
            return unitType;
        }

        public void Insert(UnitType unittype)
        {
            bTLContext.UnitTypes.Add(unittype);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, UnitType unittype)
        {
            UnitType OldUnitType = GetUnitType(id);
            OldUnitType.UnitTypeName = unittype.UnitTypeName;
            bTLContext.UnitTypes.Update(OldUnitType);
            Save();
        }
    }
}
