using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class UnitDetailRepository 
    {
        BTLContext bTLContext;
        public UnitDetailRepository(BTLContext _bTLContext)
        {
            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                UnitDetail UnitDetailToDelete = GetUnitDetail(id);
                if (UnitDetailToDelete != null)
                {
                    var unitupdate = bTLContext.Units.Where(n => n.IsDeleted == false && n.UnitId == UnitDetailToDelete.UnitId).FirstOrDefault();
                    if (unitupdate != null)
                    {
                        unitupdate.Count += UnitDetailToDelete.UnitDetailCount;
                        bTLContext.Units.Update(unitupdate);
                        Save();
                    }
                    UnitDetailToDelete.IsDeleted = true;
                    bTLContext.UnitDetails.Update(UnitDetailToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the UnitDetail: {ex.Message}");
                throw;
            }
        }
        public UnitDetail GetUnitDetail(string id)
        {
            try
            {
                return bTLContext.UnitDetails.FirstOrDefault(a => a.UnitDetailId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the UnitDetail: {ex.Message}");
                throw;
            }
        }
        public List<UnitDetail> GetUnitDetails()
        {
            try
            {
                return bTLContext.UnitDetails
                    .Where(n => !n.IsDeleted)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving UnitDetails: {ex.Message}");
                throw;
            }
        }
        public List<UnitDetail> GetUnitDetails(string IdUnit)
        {
            // i will return all unit Details based on the unit id 
            try
            {
                return bTLContext.UnitDetails
                    .Where(n => !n.IsDeleted && n.UnitId==IdUnit) 
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving UnitDetails: {ex.Message}");
                throw;
            }
        }
        public void Insert(UnitDetail unitDetail)
        {
            try
            {
                unitDetail.TypeInserted = "Minus";
                bTLContext.UnitDetails.Add(unitDetail);

                var unitupdate = bTLContext.Units.Where(n => n.IsDeleted == false && n.UnitId == unitDetail.UnitId).FirstOrDefault();
                if (unitupdate != null)
                {
                    unitupdate.Count -= unitDetail.UnitDetailCount;

                    bTLContext.Units.Update(unitupdate);
                    Save();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the UnitDetail: {ex.Message}");
                throw;
            }
        }
        public void Add(UnitDetail unitDetail)
        {
            try
            {
                bTLContext.UnitDetails.Add(unitDetail);

                var unitupdate =bTLContext.Units.Where(n=>n.IsDeleted==false && n.UnitId == unitDetail.UnitId).FirstOrDefault();
                if (unitupdate!=null)
                {
                    unitupdate.Count += unitDetail.UnitDetailCount;
                    bTLContext.Units.Update(unitupdate);
                    Save();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the UnitDetail: {ex.Message}");
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
        public void Update(string id, UnitDetail UnitDetail)
        {
            try
            {
                UnitDetail oldUnitDetail = GetUnitDetail(id);
                if (oldUnitDetail != null)
                {
                    oldUnitDetail.UnitDate = UnitDetail.UnitDate;
                    oldUnitDetail.UnitDetailCount = UnitDetail.UnitDetailCount;
                    Unit unitupdate = new Unit();
                    unitupdate.UnitId = oldUnitDetail.UnitId;
                    unitupdate.Count += oldUnitDetail.UnitDetailCount;

                    bTLContext.Units.Update(unitupdate);
                    bTLContext.UnitDetails.Update(oldUnitDetail);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the UnitDetail: {ex.Message}");
                throw;
            }
        }
    }
}
