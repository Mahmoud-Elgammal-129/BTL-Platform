using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class VisitDetailRepository
    {
        BTLContext bTLContext;
        public VisitDetailRepository(BTLContext _bTLContext)
        {
            bTLContext = _bTLContext;
        }

        public VisitDetail GetVisitDetail(string id)
        {
            try
            {
                return bTLContext.VisitDetails.FirstOrDefault(a => a.VisitDetailId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the VisitDetail: {ex.Message}");
                throw;
            }
        }

        public List<VisitDetail> GetVisitDetails(string id)
        {
            try
            {
                return bTLContext.VisitDetails
                    .Where(n => !n.IsDeleted && n.VisitId == id)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving VisitDetails: {ex.Message}");
                throw;
            }
        }
        public void Insert(VisitDetail VisitDetail)
        {
            try
            {
                bTLContext.VisitDetails.Add(VisitDetail);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the VisitDetail: {ex.Message}");
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

    }
}
