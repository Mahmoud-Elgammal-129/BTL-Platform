using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.ViewModels;

namespace BTL_Platform.Repository
{
    public class VisitTypeRepository : IVisitTypeRepository
    {
        BTLContext bTLContext;
        public VisitTypeRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                VisitType oldVisitType = GetVisitType(id);
                if (oldVisitType != null)
                {
                    oldVisitType.IsDeleted = true;
                    bTLContext.VisitTypes.Update(oldVisitType);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the visit type: {ex.Message}");
                throw;
            }
        }

        public List<VisitType> GetVisitTypes()
        {
            try
            {
                return bTLContext.VisitTypes.Where(n => !n.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving visit types: {ex.Message}");
                throw;
            }
        }

        public VisitType GetVisitType(string id)
        {
            try
            {
                return bTLContext.VisitTypes.FirstOrDefault(a => a.VisitTypeId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the visit type: {ex.Message}");
                throw;
            }
        }

        public void Insert(VisitType visitType)
        {
            try
            {
                bTLContext.VisitTypes.Add(visitType);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the visit type: {ex.Message}");
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

        public void Update(string id, VisitType visitType)
        {
            try
            {
                VisitType oldVisitType = GetVisitType(id);
                if (oldVisitType != null)
                {
                    oldVisitType.VisitTypeName = visitType.VisitTypeName;
                    bTLContext.VisitTypes.Update(oldVisitType);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the visit type: {ex.Message}");
                throw;
            }
        }
    }
}
