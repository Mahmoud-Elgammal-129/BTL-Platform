using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class VisitType
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public VisitType()
        {
            VisitTypeId = GenerateUniqueId();
        }
        [Key]
        public string VisitTypeId { get; set; }
        public string VisitTypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
    
    }
}
