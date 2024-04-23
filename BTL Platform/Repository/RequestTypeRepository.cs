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
            try
            {
                RequestType requestTypeToDelete = GetRequestType(id);
                if (requestTypeToDelete != null)
                {
                    requestTypeToDelete.IsDeleted = true;
                    bTLContext.RequestTypes.Update(requestTypeToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the request type: {ex.Message}");
                throw;
            }
        }

        public RequestType GetRequestType(string id)
        {
            try
            {
                return bTLContext.RequestTypes.FirstOrDefault(n => n.RequestTypeID == id && !n.IsDeleted);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the request type: {ex.Message}");
                throw;
            }
        }

        public List<RequestType> GetRequestTypes()
        {
            try
            {
                return bTLContext.RequestTypes.Where(n => !n.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving request types: {ex.Message}");
                throw;
            }
        }

        public void Insert(RequestType requesttype)
        {
            try
            {
                bTLContext.RequestTypes.Add(requesttype);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the request type: {ex.Message}");
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

        public void Update(string id, RequestType requestType)
        {
            try
            {
                if (id != null)
                {
                    RequestType oldRequestType = GetRequestType(id);
                    if (oldRequestType != null)
                    {
                        oldRequestType.TypeName = requestType.TypeName;
                        bTLContext.RequestTypes.Update(oldRequestType);
                        Save();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the request type: {ex.Message}");
                throw;
            }
           
        }
    }
}

