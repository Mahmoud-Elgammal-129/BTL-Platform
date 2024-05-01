using BTL_Platform.Intrface;
using BTL_Platform.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BTL_Platform.Repository
{
    public class UnitRepository : IUnitRepository
    {
        BTLContext bTLContext;
        public UnitRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                Unit unitToDelete = GetUnit(id);
                if (unitToDelete != null)
                {
                    unitToDelete.IsDeleted = true;
                    bTLContext.Units.Update(unitToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the unit: {ex.Message}");
                throw;
            }
        }

        public Unit GetUnit(string id)
        {
            try
            {
                return bTLContext.Units.FirstOrDefault(a => a.UnitId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the unit: {ex.Message}");
                throw;
            }
        }

        public List<Unit> GetUnits()
        {
            try
            {
                return bTLContext.Units
                    .Where(n => !n.IsDeleted)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving units: {ex.Message}");
                throw;
            }
        }

        public void Insert(Unit unit)
        {
            try
            {
                bTLContext.Units.Add(unit);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the unit: {ex.Message}");
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

        public void Update(string id, Unit unit)
        {
            try
            {
                Unit oldUnit = GetUnit(id);
                if (oldUnit != null)
                {
                    oldUnit.UnitName = unit.UnitName;
                    oldUnit.Count=unit.Count;
                    oldUnit.UnitNumber = unit.UnitNumber;
                    bTLContext.Units.Update(oldUnit);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the unit: {ex.Message}");
                throw;
            }
        }
    }
}
