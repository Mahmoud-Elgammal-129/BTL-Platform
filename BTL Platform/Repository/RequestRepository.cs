
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
            public void Delete(long id)
            {
            Request requestToDelete = GetRequest(id);
            if (requestToDelete != null)
            {
                requestToDelete.IsDeleted = true;
                bTLContext.Requests.Update(requestToDelete);
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
            
            }

            public Request GetRequest(long id)
            {
            Request request = bTLContext.Requests.FirstOrDefault(a => a.RequestID == id && a.IsDeleted == false);
                return request;
            }

            public List<Request> GetRequests()
            {
           var request= bTLContext.Requests.Where(n=>n.IsDeleted==false).ToList();
            return request;
            }

            public void Insert(Request request)
            {
                bTLContext.Requests.Add(request);
                bTLContext.SaveChanges();
            }

            public void Save()
            {
                bTLContext.SaveChanges();
            }

            public void Update(long id, Request request)
            {
            //get old
                 Request oldRequest = GetRequest(id);
                oldRequest.RequestDate = request.RequestDate;
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
    }


