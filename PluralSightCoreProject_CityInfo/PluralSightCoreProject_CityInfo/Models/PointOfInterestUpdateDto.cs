using System.ComponentModel.DataAnnotations;

namespace PluralSightCoreProject_CityInfo.Models
{
    public class PointOfInterestUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
