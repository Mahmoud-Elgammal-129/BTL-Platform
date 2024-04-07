using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class UnitVM
    {
        [Key]
        public long UnitId { get; set; }

        [Required(ErrorMessage = "Unit name is required")]
        public string? UnitName { get; set; }

        [Required(ErrorMessage = "Unit number is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Unit number must be a positive integer")]
        public int UnitNumber { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
