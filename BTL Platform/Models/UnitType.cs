using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class UnitType
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public UnitType()
        {
            UnitTypeId = GenerateUniqueId();
        }
        [Key]
        public string UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;


    }
}
