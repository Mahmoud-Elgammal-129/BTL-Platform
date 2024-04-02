using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class UnitType
    {
        [Key]
        public long UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;


    }
}
