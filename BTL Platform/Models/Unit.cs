using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Unit
    {
        [Key]
        public long UnitId { get; set; }
        public long UnitName { get; set; }
        public int UnitNumber { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Visit))]
        public long VisitId { get; set; }
        public virtual Visit? Visit { get; set; }
    }
}
