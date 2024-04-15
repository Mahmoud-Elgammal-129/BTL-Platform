using BTL_Platform.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class VisitStatus
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public VisitStatus()
        {
            VisitStatusId = GenerateUniqueId();
        }
        [Key]
        public string VisitStatusId { get; set; }
        public string VisitStatusName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; }
     

    }
}
