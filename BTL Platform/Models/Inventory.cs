using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Inventory
    {
        [Key]
        public long InventoryId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int count { get; set; }
        public string Status { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(unit))]
        public long unit_Id { get; set; }
        public virtual Unit? unit { get; set; }
    }
}
