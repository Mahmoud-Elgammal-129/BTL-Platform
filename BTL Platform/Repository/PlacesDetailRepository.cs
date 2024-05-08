using BTL_Platform.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Repository
{
    public class PlacesDetailRepository
    {
        BTLContext bTLContext;
        public PlacesDetailRepository(BTLContext _bTLContext)
        {
            bTLContext = _bTLContext;
        }
        public List<PlacesDetail> GetPlacesDetails(string id)
        {
            
            try
            {
                return bTLContext.PlacesDetails.Include(n => n.Places).Include(n=>n.unit).Where(a => a.PlacesId == id && !a.IsDeleted).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving PlacesDetails: {ex.Message}");
                throw;
            }
        }

        public PlacesDetail GetPlacesDetail(string id)
        {
            try
            {
                return bTLContext.PlacesDetails.Include(n => n.Places).FirstOrDefault(a => a.PlacesId == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the PlacesDetail: {ex.Message}");
                throw;
            }
        }
        public void Insert(PlacesDetail PlacesDetail)
        {
            try
            {

                bTLContext.PlacesDetails.Add(PlacesDetail);

                Save();
                //var unitupdate = bTLContext.Units.Where(n => n.IsDeleted == false && n.UnitId == PlacesDetail.unitId).FirstOrDefault();

                //if (unitupdate != null)
                //{
                //    unitupdate.Count -= PlacesDetail.PlacesDetailCount;

                //    bTLContext.Units.Update(unitupdate);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the PlacesDetail: {ex.Message}");
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
