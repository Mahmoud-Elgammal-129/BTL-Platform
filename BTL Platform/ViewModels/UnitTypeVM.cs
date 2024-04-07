using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class UnitTypeVM
    {
        [Key]
        public long UnitTypeId { get; set; }

        [Required(ErrorMessage = "Unit type name is required")]
        public string UnitTypeName { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
