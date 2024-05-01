using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.Models
{
    public class VisitDetail
    {

        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public VisitDetail()
        {
            VisitDetailId = GenerateUniqueId();
        }
        [Key]
        public string VisitDetailId { get; set; }
        public int VisitDetailCount { get; set; }
        public DateTime VisitDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(Visit))]
        public string VisitId { get; set; }
        public virtual Visit? Visit { get; set; }







    }
}
