using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class VisitStatusVM
    {
        [Key]
        public long VisitStatusId { get; set; }

        [Required(ErrorMessage = "IVisitRepository status name is required")]
        public string VisitStatusName { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
