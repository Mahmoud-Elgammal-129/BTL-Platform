using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IRequestTypeRepository
    {
        List<RequestType> GetRequestTypes();
        RequestType GetRequestType(long id);

        void Insert(RequestType requesttype);
        void Update(long id, RequestType requestType);
        void Delete(long id);
        void Save();
    }
}

