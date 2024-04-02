
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
                Request oldRequest = GetRequest(id);
                bTLContext.Requests.Remove(oldRequest);
                Save();
            }

            public Request GetRequest(long id)
            {
                Request request = bTLContext.Requests.FirstOrDefault(a => a.RequestID == id);
                return request;
            }

            public List<Request> GetRequests()
            {
            var request= bTLContext.Requests./*Include(r => r.Request_type.TypeName).*/ToList();
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

            }
        }
    }


