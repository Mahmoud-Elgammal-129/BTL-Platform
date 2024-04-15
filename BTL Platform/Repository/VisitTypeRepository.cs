using BTL_Platform.Intrface;
using BTL_Platform.Models;
using BTL_Platform.ViewModels;

namespace BTL_Platform.Repository
{
    public class VisitTypeRepository : IVisitTypeRepository
    {
        BTLContext bTLContext;
        public VisitTypeRepository(BTLContext _bTLContext)
        {

            bTLContext = _bTLContext;
        }
        public void Delete(string id)
        {
            VisitType OldvisitType = GetVisitType(id);
            if (OldvisitType != null)
            {
                OldvisitType.IsDeleted = true;
                //Update(requestToDelete);
                Save(); // Save method should handle the changes
            }
        }

        public List<VisitType> GetVisitTypes()
        {
            var visitType = bTLContext.VisitTypes.Where(n=>n.IsDeleted==false).ToList();
            return visitType;
        }

        public VisitType GetVisitType(string id)
        {
            VisitType visitType = bTLContext.VisitTypes.FirstOrDefault(a => a.VisitTypeId == id && a.IsDeleted == false);
            return visitType;
        }

        public void Insert(VisitType visittype)
        {
            bTLContext.VisitTypes.Add(visittype);
            bTLContext.SaveChanges();
        }

        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(string id, VisitType visittype)
        {
            VisitType OldvisitType = GetVisitType(id);
            OldvisitType.VisitTypeName = visittype.VisitTypeName;
            bTLContext.VisitTypes.Update(OldvisitType);
            Save();
        }
    }
}
