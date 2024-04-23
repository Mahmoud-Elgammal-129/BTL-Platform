
using BTL_Platform.Intrface;
using BTL_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Reposatiory
{
    public class RequestRepository : IRequestRepository
    {
        BTLContext bTLContext;
        public RequestRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                Request requestToDelete = GetRequest(id);
                if (requestToDelete != null)
                {
                    requestToDelete.IsDeleted = true;
                    bTLContext.Requests.Update(requestToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"An error occurred while deleting the request: {ex.Message}");
                throw; // Rethrow the exception to propagate it
            }
        }

        public Request GetRequest(string id)
        {
            try
            {
                return bTLContext.Requests.FirstOrDefault(a => a.RequestID == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the request: {ex.Message}");
                throw;
            }
        }

        public List<Request> GetRequests()
        {
            try
            {
                return bTLContext.Requests.Where(n => !n.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving requests: {ex.Message}");
                throw;
            }
        }

        public void Insert(Request request)
        {
            try
            {
                bTLContext.Requests.Add(request);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the request: {ex.Message}");
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

        public List<Request> SearchRequest(string searchValue)
        {
            try
            {
                return bTLContext.Requests
                    .Where(c =>
                        c.CompanyName.Contains(searchValue) ||
                        c.ClientEmail.Contains(searchValue) ||
                        c.ClientMobile.ToString().Contains(searchValue))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching requests: {ex.Message}");
                throw;
            }
        }

        public void Update(string id, Request request)
        {
            try
            {
                Request oldRequest = GetRequest(id);
                if (oldRequest != null)
                {
                    oldRequest.CompanyName = request.CompanyName;
                    oldRequest.ClientMobile = request.ClientMobile;
                    oldRequest.ClientEmail = request.ClientEmail;
                    oldRequest.Channel = request.Channel;
                    oldRequest.Description = request.Description;
                    oldRequest.Assignee = request.Assignee;
                    oldRequest.WH_movements = request.WH_movements;
                    oldRequest.Status = request.Status;
                    oldRequest.Priority = request.Priority;
                    oldRequest.POSNumber = request.POSNumber;
                    oldRequest.OnGroundTeams = request.OnGroundTeams;
                    oldRequest.TrucksNeeded = request.TrucksNeeded;
                    oldRequest.StartDate = request.StartDate;
                    oldRequest.EndDate = request.EndDate;
                    bTLContext.Requests.Update(oldRequest);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the request: {ex.Message}");
                throw;
            }
        }
    }
}


