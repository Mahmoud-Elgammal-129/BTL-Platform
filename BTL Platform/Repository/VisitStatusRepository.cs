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
        public void Delete(long id)
        {
            VisitStatus VisitStatusToDelete = GetVisitStatus(id);
            if (VisitStatusToDelete != null)
            {
                VisitStatusToDelete.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public VisitStatus GetVisitStatus(long id)
        {
            VisitStatus visitStatus = bTLContext.VisitStatuses.FirstOrDefault(a => a.VisitStatusId == id);
            return visitStatus;
        }

        public List<VisitStatus> GetVisitStatuss()
        {
            var visitStatus = bTLContext.VisitStatuses.ToList();
            return visitStatus;
        }

        public void Insert(VisitStatus visitstatus)
        {
            bTLContext.VisitStatuses.Add(visitstatus);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, VisitStatus visitstatus)
        {
            VisitStatus OldVisitStatus = GetVisitStatus(id);
            OldVisitStatus.VisitStatusName = visitstatus.VisitStatusName;
            bTLContext.VisitStatuses.Update(OldVisitStatus);
            Save();
        }
    }
}
