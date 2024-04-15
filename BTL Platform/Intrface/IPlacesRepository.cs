using BTL_Platform.Models;
using System.Diagnostics;

namespace BTL_Platform.Intrface
{
    public interface IPlacesRepository
    {
        List<Places> GetPlacess();
        Places GetPlaces(string id);

        void Insert(Places places);
        void Update(string id, Places places);
        void Delete(string id);
        void Save();
    }
}
