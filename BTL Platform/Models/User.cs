using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Team { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }=false;
        


    }
}
