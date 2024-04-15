using BTL_Platform.Intrface;
using BTL_Platform.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Repository
{
    public class VisitRepository : IVisitRepository
    {
        BTLContext bTLContext;
        public VisitRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            Visit VisitToDelete = GetVisit(id);
            if (VisitToDelete != null)
            {
                VisitToDelete.IsDeleted = true;
                bTLContext.Visits.Update(VisitToDelete);
                Save();
            }
        }

        public Visit GetVisit(string id)
        {
            Visit Visit = bTLContext.Visits.Include(n=>n.User).Include(n => n.VisitType).Include(n => n.VisitStatus).Include(n => n.Place).FirstOrDefault(a => a.VisitId == id && a.IsDeleted == false);
            return Visit;
        }

        public List<Visit> GetVisits()
        {
            var Visit = bTLContext.Visits.Where(n => n.IsDeleted == false).Include(n => n.User).Include(n => n.VisitStatus).Include(n => n.Place).Include(n => n.VisitType).ToList();
            return Visit;
        }

        public void Insert(Visit Visit)
        {
            bTLContext.Visits.Add(Visit);
            bTLContext.SaveChanges();
        }

        public void Insert(List<Visit> visits)
        {
            bTLContext.Visits.AddRange(visits);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(string id, Visit Visit)
        {
            Visit OldVisit = GetVisit(id);
            OldVisit.UTCoffset = Visit.UTCoffset;
            OldVisit.POSPhoto = Visit.POSPhoto;
            OldVisit.UnitsPhotobefore = Visit.UnitsPhotobefore;
            OldVisit.UnitsPhotoAfter = Visit.UnitsPhotoAfter;
            OldVisit.placeName = Visit.placeName;
            OldVisit.placeChain = Visit.placeChain;
            OldVisit.Status = Visit.Status;
            OldVisit.Notes = Visit.Notes;
            OldVisit.UserName = Visit.UserName;
            OldVisit.PlannedDate = Visit.PlannedDate;
            OldVisit.TaskId = Visit.TaskId;
            OldVisit.TaskName = Visit.TaskName;
            OldVisit.UnitsNumbers = Visit.UnitsNumbers;
            OldVisit.RequestID = Visit.RequestID;
            OldVisit.Id = Visit.Id;
            OldVisit.VisitStatusId = Visit.VisitStatusId;
            OldVisit.VisitTypeId = Visit.VisitTypeId;
            OldVisit.Place_Id = Visit.Place_Id;
            bTLContext.Visits.Update(OldVisit);
            Save();
        }
    }
}
