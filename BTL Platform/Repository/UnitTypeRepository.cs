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
        public void Delete(string id)
        {
            try
            {
                UnitType unitTypeToDelete = GetUnitType(id);
                if (unitTypeToDelete != null)
                {
                    unitTypeToDelete.IsDeleted = true;
                    bTLContext.UnitTypes.Update(unitTypeToDelete);
                    Save(); // Save method should handle the changes
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the unit type: {ex.Message}");
                throw;
            }
        }

        public UnitType GetUnitType(string id)
        {
            try
            {
                return bTLContext.UnitTypes.FirstOrDefault(a => a.UnitTypeId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the unit type: {ex.Message}");
                throw;
            }
        }

        public List<UnitType> GetUnitTypes()
        {
            try
            {
                return bTLContext.UnitTypes.Where(n => !n.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving unit types: {ex.Message}");
                throw;
            }
        }

        public void Insert(UnitType unitType)
        {
            try
            {
                bTLContext.UnitTypes.Add(unitType);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the unit type: {ex.Message}");
                throw;
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
                Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
                throw;
            }
        }

        public void Update(string id, UnitType unitType)
        {
            try
            {
                UnitType oldUnitType = GetUnitType(id);
                if (oldUnitType != null)
                {
                    oldUnitType.UnitTypeName = unitType.UnitTypeName;
                    bTLContext.UnitTypes.Update(oldUnitType);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the unit type: {ex.Message}");
                throw;
            }
        }
    }
}
