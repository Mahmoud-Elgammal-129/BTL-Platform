
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

        [Required(ErrorMessage = "Item name is required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count must be a positive number")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public bool IsDeleted { get; set; } = false;

        
    }
}
