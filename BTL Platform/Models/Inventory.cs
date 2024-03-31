using System.ComponentModel.DataAnnotations;

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
        public bool IsDeleted { get; set; }
    }
}
