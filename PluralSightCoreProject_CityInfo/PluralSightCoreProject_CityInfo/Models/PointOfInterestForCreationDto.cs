using System.ComponentModel.DataAnnotations;

namespace PluralSightCoreProject_CityInfo.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
