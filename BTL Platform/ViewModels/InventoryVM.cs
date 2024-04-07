using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class InventoryVM
    {

        [Key]
        public long InventoryId { get; set; }

        [Required(ErrorMessage = "Item name is required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count must be a positive number")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
