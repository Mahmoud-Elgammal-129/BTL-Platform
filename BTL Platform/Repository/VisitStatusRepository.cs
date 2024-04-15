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
            VisitStatus VisitStatusToDelete = GetVisitStatus(id);
            if (VisitStatusToDelete != null)
            {
                VisitStatusToDelete.IsDeleted = true;
                bTLContext.VisitStatuses.Update(VisitStatusToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public VisitStatus GetVisitStatus(string id)
        {
            VisitStatus visitStatus = bTLContext.VisitStatuses.FirstOrDefault(a => a.VisitStatusId == id &&a.IsDeleted==false);
            return visitStatus;
        }

        public List<VisitStatus> GetVisitStatuss()
        {
            var visitStatus = bTLContext.VisitStatuses.Where(a=> a.IsDeleted == false).ToList();
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

        public void Update(string id, VisitStatus visitstatus)
        {
            VisitStatus OldVisitStatus = GetVisitStatus(id);
            OldVisitStatus.VisitStatusName = visitstatus.VisitStatusName;
            bTLContext.VisitStatuses.Update(OldVisitStatus);
            Save();
        }
    }
}
