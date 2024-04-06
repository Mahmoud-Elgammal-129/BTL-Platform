using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Unit
    {
        [Key]
        public long UnitId { get; set; }
        public string? UnitName { get; set; }
        public int UnitNumber { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }=false;
        [ForeignKey(nameof(Unit_type))]
        public long Unit_type_Id { get; set; }
        public virtual UnitType? Unit_type { get; set; }
        [ForeignKey(nameof(inventory))]
        public long InventoryId { get; set; }
        public virtual Inventory? inventory { get; set; }


    }
}
