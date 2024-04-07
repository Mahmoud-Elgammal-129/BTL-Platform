using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitStatusRepository
    {
        List<VisitStatus> GetVisitStatuss();
        VisitStatus GetVisitStatus(long id);

        void Insert(VisitStatus visitstatus);
        void Update(long id, VisitStatus visitstatus);
        void Delete(long id);
        void Save();
    }
}
