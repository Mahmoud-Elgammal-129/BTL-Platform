
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Inventory
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Inventory()
        {
            InventoryId = GenerateUniqueId();
        }
        [Key]
        public string InventoryId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int count { get; set; }
        public string Status { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;

        
    }
}
