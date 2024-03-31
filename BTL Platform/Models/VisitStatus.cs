using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class VisitStatus
    {
        [Key]
        public long VisitStatusId { get; set; }
        public string VisitStatusName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
     

    }
}
