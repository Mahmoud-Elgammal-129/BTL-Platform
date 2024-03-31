using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class VisitType
    {
        [Key]
        public long VisitTypeId { get; set; }
        public string VisitTypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
    
    }
}
