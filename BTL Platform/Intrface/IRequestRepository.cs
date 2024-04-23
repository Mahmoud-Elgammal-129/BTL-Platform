
using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IRequestRepository
    {
        List<Request> GetRequests();
        Request GetRequest(string id);

        void Insert(Request request);
        void Update(string id, Request request);
        void Delete(string id);
        void Save();
        List<Request> SearchRequest(string searchValue);
    }
}
