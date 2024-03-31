using Microsoft.AspNetCore.Identity;

namespace BTL_Platform.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? address { get; set; }
        public string Name { get; set; }
    }
}
