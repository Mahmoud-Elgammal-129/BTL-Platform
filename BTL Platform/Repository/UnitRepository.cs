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
        public void Delete(long id)
        {
            Unit UnitToDelete = GetUnit(id);
            if (UnitToDelete != null)
            {
                UnitToDelete.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public Unit GetUnit(long id)
        {
            Unit unit = bTLContext.Units.FirstOrDefault(a => a.UnitId == id);
            return unit;
        }

        public List<Unit> GetUnits()
        {
            var unit = bTLContext.Units.Include(r => r.Unit_type).Include(i=>i.inventory).ToList();
            return unit;
        }

        public void Insert(Unit unit)
        {
            bTLContext.Units.Add(unit);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, Unit unit)
        {
            Unit OldUnit = GetUnit(id);
            OldUnit.UnitName = unit.UnitName;
            OldUnit.UnitNumber = unit.UnitNumber;
          
            bTLContext.Units.Update(OldUnit);
            Save();
        }
    }
}
