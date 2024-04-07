using Azure.Core;
using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        BTLContext bTLContext;
        public RequestTypeRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
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
    }
}

