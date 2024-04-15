using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_Platform.Models
{
    public class Places
    {
        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public Places()
        {
            Id = GenerateUniqueId();
        }
        [Key]
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string PlaceId { get; set; }
        public string Chain { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Channel { get; set; }
        public string UnitNumber { get; set; }
        public string UnitType { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public DateTime lastupdated { get; set; }=DateTime.Now;
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;

    }
}
