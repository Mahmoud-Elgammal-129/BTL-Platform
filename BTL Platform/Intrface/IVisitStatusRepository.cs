using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitStatusRepository
    {
        List<VisitStatus> GetVisitStatuss();
        VisitStatus GetVisitStatus(string id);

        void Insert(VisitStatus visitstatus);
        void Update(string id, VisitStatus visitstatus);
        void Delete(string id);
        void Save();
    }
}
