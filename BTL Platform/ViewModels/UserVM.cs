using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.ViewModels
{
    public class UserVM
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string Team { get; set; }

        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;
    }
}
