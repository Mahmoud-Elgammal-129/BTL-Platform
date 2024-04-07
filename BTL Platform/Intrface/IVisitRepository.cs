using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitRepository
    {
        List<Visit> GetVisits();
        Visit GetVisits(long id);

        void Insert(Visit visit);
        void Update(long id, Visit visit);
        void Delete(long id);
        void Save();
    }
}
