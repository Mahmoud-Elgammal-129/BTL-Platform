using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTL_Platform.Models
{
    public class Employees
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string  FullName { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }

    }
}
