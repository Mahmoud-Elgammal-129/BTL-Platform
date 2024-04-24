using BTL_Platform.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    [PrimaryKey(nameof(InventoryId), nameof(UnitId))]
    public class InventoryUnit
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public InventoryUnit()
        {
            InventoryId = GenerateUniqueId();
            UnitId = GenerateUniqueId();
        }
        //public string InventoryId { get; set; }
        //public string UnitId { get; set; }
        public int UnitCount { get; set; }

        [ForeignKey("unit")]
        public string? UnitId { get; set; }
        public virtual Unit? unit { get; set; }

        [ForeignKey("inventory")]
        public string? InventoryId { get; set; }
        public virtual Inventory? inventory { get; set; }



    }
}
