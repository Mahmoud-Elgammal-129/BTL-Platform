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
        [Required(ErrorMessage = "UnitNumber is required")]

        public int UnitNumber { get; set; }
        
        public bool IsDeleted { get; set; }=false;
        [ForeignKey(nameof(Unit_type))]

        //[Required(ErrorMessage = "Unit_type_Id is required")]

        public string? Unit_type_Id { get; set; }

        public virtual UnitType? Unit_type { get; set; }
        
        [ForeignKey(nameof(inventory))]
        //[Required(ErrorMessage = "InventoryId is required")]

        public string? InventoryId { get; set; }
        public virtual Inventory? inventory { get; set; }


    }
}
