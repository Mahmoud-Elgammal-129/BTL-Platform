using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitRepository
    {
        List<Visit> GetVisits();
        Visit GetVisit(string id);

        void Insert(Visit visit);
        void Update(string id, Visit visit);
        void Delete(string id);
        void Save();
    }
}
