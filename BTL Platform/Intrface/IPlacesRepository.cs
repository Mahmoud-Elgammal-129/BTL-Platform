using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IPlacesRepository
    {
        List<Places> GetPlacess();
        Places GetPlaces(long id);

        void Insert(Places places);
        void Update(long id, Places places);
        void Delete(long id);
        void Save();
    }
}
