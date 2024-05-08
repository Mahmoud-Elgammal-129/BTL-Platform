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
            try
            {
                Visit visitToDelete = GetVisit(id);
                if (visitToDelete != null)
                {
                    visitToDelete.IsDeleted = true;
                    bTLContext.Visits.Update(visitToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the visit: {ex.Message}");
                throw;
            }
        }

        public Visit GetVisit(string id)
        {
            try
            {
                return bTLContext.Visits.Include(n => n.User)
                                          .Include(n => n.visitType)
                                          .Include(n => n.visitStatus)
                                          .Include(n => n.Place)
                                          .FirstOrDefault(a => a.VisitId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the visit: {ex.Message}");
                throw;
            }
        }

        public List<Visit> GetVisits()
        {
            try
            {
                return bTLContext.Visits.Where(n => !n.IsDeleted)
                                          .Include(n => n.User)
                                          .Include(n => n.visitStatus)
                                          .Include(n => n.Place)
                                          .Include(n => n.visitType)
                                          .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving visits: {ex.Message}");
                throw;
            }
        }

        public void Insert(Visit visit)
        {
            try
            {
                bTLContext.Visits.Add(visit);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the visit: {ex.Message}");
                throw;
            }
        }

        public void Insert(List<Visit> visits)
        {
            try
            {
                bTLContext.Visits.AddRange(visits);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the visits: {ex.Message}");
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

        public void Update(string id, Visit visit)
        {
            try
            {
                Visit oldVisit = GetVisit(id);
                if (oldVisit != null)
                {
                    oldVisit.UTCoffset = visit.UTCoffset;
                    oldVisit.POSPhoto = visit.POSPhoto;
                    oldVisit.UnitsPhotobefore = visit.UnitsPhotobefore;
                    oldVisit.UnitsPhotoAfter = visit.UnitsPhotoAfter;
                    oldVisit.placeName = visit.placeName;
                    oldVisit.placeChain = visit.placeChain;
                    oldVisit.Status = visit.Status;
                    oldVisit.Notes = visit.Notes;
                    oldVisit.UserName = visit.UserName;
                    oldVisit.PlannedDate = visit.PlannedDate;
                    oldVisit.TaskId = visit.TaskId;
                    oldVisit.TaskName = visit.TaskName;
                    oldVisit.UnitsNumbers = visit.UnitsNumbers;
                    oldVisit.RequestID = visit.RequestID;
                    oldVisit.Id = visit.Id;
                    oldVisit.VisitStatusId = visit.VisitStatusId;
                    oldVisit.VisitTypeId = visit.VisitTypeId;
                    oldVisit.Place_Id = visit.Place_Id;
                    bTLContext.Visits.Update(oldVisit);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the visit: {ex.Message}");
                throw;
            }
        }

        public void UpdatesList(string RequestId, List<Visit> newVisits)
        {
            // Retrieve old visits based on the request ID
            var oldVisits = GetVisitsBasedOnRequest(RequestId);

            // Loop through the old visits and update them
            foreach (var oldVisit in oldVisits)
            {
                // Find the corresponding new visit in the new list based on VisitId
                var newVisit = newVisits.FirstOrDefault(v => v.VisitId == oldVisit.VisitId);

                // Check if a corresponding new visit exists
                if (newVisit != null && newVisit.UnitsNumbers>0)
                {
                    // Update the properties of the old visit with the new values
                    oldVisit.UTCoffset = newVisit.UTCoffset;
                    oldVisit.POSPhoto = newVisit.POSPhoto;
                    oldVisit.UnitsPhotobefore = newVisit.UnitsPhotobefore;
                    oldVisit.UnitsPhotoAfter = newVisit.UnitsPhotoAfter;
                    oldVisit.placeName = newVisit.placeName;
                    oldVisit.placeChain = newVisit.placeChain;
                    oldVisit.Status = newVisit.Status;
                    oldVisit.Notes = newVisit.Notes;
                    oldVisit.UserName = newVisit.UserName;
                    oldVisit.PlannedDate = newVisit.PlannedDate;
                    oldVisit.TaskId = newVisit.TaskId;
                    oldVisit.TaskName = newVisit.TaskName;
                    oldVisit.UnitsNumbers = newVisit.UnitsNumbers;
                    oldVisit.Unit_Id = newVisit.Unit_Id;


                    // Update the old visit in the database
                    bTLContext.Visits.Update(oldVisit);
                }
            }

            // Save changes to the database
            Save();
        }
        public List<Visit> GetVisitsBasedOnRequest(string RequestId)
        {
            if (RequestId != null)
            {
                var Visits = bTLContext.Visits.Where(n => n.RequestID == RequestId).ToList();
                return Visits;
            }
            return null;
        }
    }
}
