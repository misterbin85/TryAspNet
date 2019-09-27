using System;
using System.Collections.Generic;

namespace PluralSightCoreProject_CityInfo.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        public ICollection<PointOfInterestsDto> PointsOfInterest { get; set; } = new List<PointOfInterestsDto>();
    }
}
