using BTL_Platform.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Unit
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Unit()
        {
            UnitId = GenerateUniqueId();
        }
        [Key]
        public string UnitId { get; set; }
        [Required(ErrorMessage = "UnitName is required")]

        public string? UnitName { get; set; }
        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; } 
        public int UnitNumber { get; set; }
        
        public bool IsDeleted { get; set; }=false;

        public virtual List<UnitDetail> UnitDetails { get; set;}


    }
}
