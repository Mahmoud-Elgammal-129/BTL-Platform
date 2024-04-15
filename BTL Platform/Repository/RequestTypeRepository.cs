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

        public void Delete(string id)
        {
            RequestType requestTypeToDelete = GetRequestType(id);
            if (requestTypeToDelete != null)
            {
                requestTypeToDelete.IsDeleted = true;
                bTLContext.RequestTypes.Update(requestTypeToDelete);
                Save(); 
            }
        }

        public RequestType GetRequestType(string id)
        {
            var request = bTLContext.RequestTypes;

            var result = request.Where(n => n.RequestTypeID==id&&n.IsDeleted == false).FirstOrDefault();
            return result;
        }

        public List<RequestType> GetRequestTypes()
        {
            var request = bTLContext.RequestTypes;

            var result = request.Where(n=>n.IsDeleted==false).ToList();
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

        public void Update(string id, RequestType requestType)
        {
            if (id != null)
            {
                RequestType oldRequestType = GetRequestType(id);
                if(oldRequestType != null)
                {
                    oldRequestType.TypeName = requestType.TypeName;
                    bTLContext.RequestTypes.Update(oldRequestType);
                    Save();

                }


            }
           
        }
    }
}

