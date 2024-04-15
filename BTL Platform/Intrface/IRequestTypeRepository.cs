using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IRequestTypeRepository
    {
        List<RequestType> GetRequestTypes();
        RequestType GetRequestType(string id);

        void Insert(RequestType requesttype);
        void Update(string id, RequestType requestType);
        void Delete(string id);
        void Save();
    }
}

