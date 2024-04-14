using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitRepository
    {
        List<Visit> GetVisits();
        Visit GetVisit(long id);
        void Insert(List<Visit> visits);

        void Insert(Visit visit);
        void Update(long id, Visit visit);
        void Delete(long id);
        void Save();
    }
}
