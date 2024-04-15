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
            Unit UnitToDelete = GetUnit(id);
            if (UnitToDelete != null)
            {
                UnitToDelete.IsDeleted = true;
                bTLContext.Units.Update(UnitToDelete);
                Save(); 
            }
        }

        public Unit GetUnit(string id)
        {
            Unit unit = bTLContext.Units.Include(n => n.Unit_type).Include(n=>n.inventory).FirstOrDefault(a => a.UnitId == id && a.IsDeleted == false);
            return unit;
        }

        public List<Unit> GetUnits()
        {
            var unit = bTLContext.Units.Where(n => n.IsDeleted == false).Include(n => n.Unit_type).Include(n => n.inventory).ToList();
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

        public void Update(string id, Unit unit)
        {
            Unit OldUnit = GetUnit(id);
            OldUnit.UnitName = unit.UnitName;
            OldUnit.UnitNumber = unit.UnitNumber;
          
            bTLContext.Units.Update(OldUnit);
            Save();
        }
    }
}
