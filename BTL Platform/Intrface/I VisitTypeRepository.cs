using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitTypeRepository
    {
        List<VisitType> GetVisitTypes();
        VisitType GetVisitType(string id);

        void Insert(VisitType visittype);
        void Update(string id, VisitType visittype);
        void Delete(string id);
        void Save();
    }
}
