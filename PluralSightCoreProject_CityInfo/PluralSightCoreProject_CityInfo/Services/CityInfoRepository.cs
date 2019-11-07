using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PluralSightCoreProject_CityInfo.Entities;

namespace PluralSightCoreProject_CityInfo.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }


        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id.Equals(cityId));
            }

            return _context.Cities.FirstOrDefault(city => city.Id.Equals(cityId));
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointOfInterests.FirstOrDefault(i => i.City.Id.Equals(cityId) && i.Id.Equals(pointOfInterestId));
        }

        public IEnumerable<PointOfInterest> GetPointOfInterestForCity(int cityId)
        {
            return _context.PointOfInterests.Where(p => p.CityId.Equals(cityId)).ToList();
        }
    }
}
