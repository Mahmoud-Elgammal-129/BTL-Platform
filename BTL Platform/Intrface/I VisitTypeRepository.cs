using BTL_Platform.Models;

namespace BTL_Platform.Intrface
{
    public interface IVisitTypeRepository
    {
        List<VisitType> GetVisitTypes();
        VisitType GetVisitType(long id);

        void Insert(VisitType visittype);
        void Update(long id, VisitType visittype);
        void Delete(long id);
        void Save();
    }
}
