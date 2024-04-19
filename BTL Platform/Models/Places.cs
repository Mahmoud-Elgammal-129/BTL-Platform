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
        [Required(ErrorMessage = "Display name is required")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Place ID is required")]
        public string PlaceId { get; set; }

        public string Chain { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "County is required")]
        public string County { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Channel is required")]
        public string Channel { get; set; }

        [Display(Name = "Unit Number")]
        public string UnitNumber { get; set; }

        [Display(Name = "Unit Type")]
        public string UnitType { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public decimal latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public decimal longitude { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime lastupdated { get; set; } = DateTime.Now;
        // Other properties SOFT DELETE
        public bool IsDeleted { get; set; } = false;

    }
}
