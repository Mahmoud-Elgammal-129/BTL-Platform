using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class RequestType
    {
        [Key]
        public long RequestTypeID { get; set; }
        public string? TypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }=false;
      

    }
}
