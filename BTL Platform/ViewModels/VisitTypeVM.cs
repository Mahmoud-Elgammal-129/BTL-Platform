using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class VisitTypeVM
    {
        [Key]
        public long VisitTypeId { get; set; }

        [Required(ErrorMessage = "Visit type name is required")]
        public string VisitTypeName { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
    }
}
