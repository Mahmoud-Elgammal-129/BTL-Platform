using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class RequestType
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public RequestType()
        {
            RequestTypeID = GenerateUniqueId();
        }
        [Key]
        public string RequestTypeID { get; set; }
        [Required(ErrorMessage = "Type name is required")]
        public string TypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }=false;
      

    }
}
