using BTL_Platform.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class User
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public User()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Team { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }=false;
        


    }
}
