using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
   
    public class PlacesRepository : IPlacesRepository
    {
        BTLContext bTLContext;
        public PlacesRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            try
            {
                Places placesToDelete = GetPlaces(id);
                if (placesToDelete != null)
                {
                    placesToDelete.IsDeleted = true;
                    bTLContext.Places.Update(placesToDelete);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the place: {ex.Message}");
                throw;
            }
        }

        public Places GetPlaces(string id)
        {
            try
            {
                return bTLContext.Places.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the place: {ex.Message}");
                throw;
            }
        }

        public List<Places> GetPlacess()
        {
            try
            {
                return bTLContext.Places.Where(n => !n.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving places: {ex.Message}");
                throw;
            }
        }

        public void Insert(Places places)
        {
            try
            {
                bTLContext.Places.Add(places);
                Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the place: {ex.Message}");
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

        public void Update(string id, Places places)
        {
            try
            {
                Places oldPlaces = GetPlaces(id);
                if (oldPlaces != null)
                {
                    oldPlaces.lastupdated = places.lastupdated;
                    oldPlaces.latitude = places.latitude;
                    oldPlaces.StreetNumber = places.StreetNumber;
                    oldPlaces.UnitNumber = places.UnitNumber;
                    oldPlaces.StreetName = places.StreetName;
                    oldPlaces.State = places.State;
                    oldPlaces.Chain = places.Chain;
                    oldPlaces.Channel = places.Channel;
                    oldPlaces.City = places.City;
                    oldPlaces.Country = places.Country;
                    oldPlaces.County = places.County;
                    oldPlaces.DisplayName = places.DisplayName;
                    oldPlaces.longitude = places.longitude;
                    oldPlaces.PostalCode = places.PostalCode;
                    oldPlaces.PlaceId = places.PlaceId;
                    oldPlaces.UnitType = places.UnitType;
                    bTLContext.Places.Update(oldPlaces);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the place: {ex.Message}");
                throw;
            }
        }
    }
}
