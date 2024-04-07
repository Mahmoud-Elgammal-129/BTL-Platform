using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class RequestTypeVM
    {
        [Key]
        public long RequestTypeID { get; set; }

        [Required(ErrorMessage = "Type name is required")]
        public string TypeName { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
