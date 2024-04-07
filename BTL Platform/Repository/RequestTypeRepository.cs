using Azure.Core;
using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.ViewModels;

namespace BTL_Platform.Repository
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        BTLContext bTLContext;
        public RequestTypeRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }

        public void Delete(long id)
        {
            RequestType RequestTypeToDelete = GetRequestType(id);
            if (RequestTypeToDelete != null)
            {
                RequestTypeToDelete.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public RequestType GetRequestType(long id)
        {
            RequestType requestType = bTLContext.RequestTypes.FirstOrDefault(a => a.RequestTypeID == id);
            return requestType;
        }

        public List<RequestType> GetRequestTypes()
        {
            var request = bTLContext.RequestTypes;

            var result = request.ToList();
            return result;
        }

        public void Insert(RequestType requesttype)
        {
            bTLContext.RequestTypes.Add(requesttype);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, RequestType requestType)
        {
            RequestType OldrequestType = GetRequestType(id);
            OldrequestType.TypeName = requestType.TypeName;
            bTLContext.RequestTypes.Update(OldrequestType);
            Save();
        }
    }
}

