using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTL_Platform.Models
{
    public class PlacesDetail
    {

        private string GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public PlacesDetail()
        {
            PlacesDetailId = GenerateUniqueId();
        }
        [Key]
        public string PlacesDetailId { get; set; }
        public int PlacesDetailCount { get; set; }
        public DateTime PlacesDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey(nameof(Places))]
        public string PlacesId { get; set; }
        public virtual Places? Places { get; set; }


        [ForeignKey(nameof(unit))]
        public string unitId { get; set; }
        public virtual Unit? unit { get; set; }



    }
}
