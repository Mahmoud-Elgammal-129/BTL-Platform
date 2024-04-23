using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.ViewModels;

namespace BTL_Platform.Repository
{
    public class VisitStatusRepository : IVisitStatusRepository
    {
        BTLContext bTLContext;
        public VisitStatusRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                VisitStatus visitStatusToDelete = GetVisitStatus(id);
                if (visitStatusToDelete != null)
                {
                    visitStatusToDelete.IsDeleted = true;
                    bTLContext.VisitStatuses.Update(visitStatusToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the visit status: {ex.Message}");
                throw;
            }
        }

        public VisitStatus GetVisitStatus(string id)
        {
            try
            {
                return bTLContext.VisitStatuses.FirstOrDefault(a => a.VisitStatusId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the visit status: {ex.Message}");
                throw;
            }
        }

        public List<VisitStatus> GetVisitStatuss()
        {
            try
            {
                return bTLContext.VisitStatuses.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving visit statuses: {ex.Message}");
                throw;
            }
        }

       

        public void Insert(VisitStatus visitStatus)
        {
            try
            {
                bTLContext.VisitStatuses.Add(visitStatus);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the visit status: {ex.Message}");
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

        public void Update(string id, VisitStatus visitStatus)
        {
            try
            {
                VisitStatus oldVisitStatus = GetVisitStatus(id);
                if (oldVisitStatus != null)
                {
                    oldVisitStatus.VisitStatusName = visitStatus.VisitStatusName;
                    bTLContext.VisitStatuses.Update(oldVisitStatus);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the visit status: {ex.Message}");
                throw;
            }
        }
    }
}
