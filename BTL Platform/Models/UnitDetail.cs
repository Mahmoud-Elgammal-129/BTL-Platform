using BTL_Platform.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class UnitDetail
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public UnitDetail()
        {
            UnitDetailId = GenerateUniqueId();
        }
        [Key]
        public string UnitDetailId { get; set; }
        public int UnitDetailCount { get; set; }
        public DateTime UnitDate { get; set; }
        public string  TypeInserted { get; set; }
        public bool IsDeleted { get; set; }=false;

        [ForeignKey(nameof(unit))]
        public string UnitId { get; set; }
        public virtual Unit? unit { get; set; }


    }
}
