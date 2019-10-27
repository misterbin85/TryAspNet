using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace PluralSightCoreProject_CityInfo.Entities
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            var cities = new List<City>
            {
                new City
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States"
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan"
                        },
                        new PointOfInterest()
                        {
                            Name = "Some interest",
                            Description = "Bla Bla Bla"
                        }
                    }
                },
                new City
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new City
                {
                    Name = "Paris",
                    Description = "The one with that big tower."
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}