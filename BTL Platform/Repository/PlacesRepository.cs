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
        public void Delete(long id)
        {
            Places PlacesToDelete = GetPlaces(id);
            if (PlacesToDelete != null)
            {
                PlacesToDelete.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public Places GetPlaces(long id)
        {
            Places places = bTLContext.Places.FirstOrDefault(a => a.Id == id);
            return places;
        }

        public List<Places> GetPlacess()
        {
            var places = bTLContext.Places.ToList();
            return places;
        }

        public void Insert(Places places)
        {
            bTLContext.Places.Add(places);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(long id, Places places)
        {
            Places OldPlaces = GetPlaces(id);

            OldPlaces.lastupdated = places.lastupdated;
            OldPlaces.latitude = places.latitude;
            OldPlaces.StreetNumber = places.StreetNumber;
            OldPlaces.UnitNumber = places.UnitNumber;
            OldPlaces.StreetName = places.StreetName;
            OldPlaces.State = places.State;
            OldPlaces.Chain = places.Chain;
            OldPlaces.Channel = places.Channel;
            OldPlaces.City = places.City;
            OldPlaces.Country = places.Country;
            OldPlaces.County = places.County;
            OldPlaces.DisplayName = places.DisplayName;
            OldPlaces.longitude = places.longitude;
            OldPlaces.PostalCode = places.PostalCode;
            OldPlaces.PlaceId = places.PlaceId;
            OldPlaces.UnitType = places.UnitType;
            bTLContext.Places.Update(OldPlaces);
            Save();
        }
    }
}
