
using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IRequestRepository
    {
        List<Request> GetRequests();
        Request GetRequest(long id);

        void Insert(Request request);
        void Update(long id, Request request);
        void Delete(long id);
        void Save();
    }
}
