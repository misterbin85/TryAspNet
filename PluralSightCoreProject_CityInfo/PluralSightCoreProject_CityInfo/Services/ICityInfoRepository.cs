using System.Collections.Generic;
using PluralSightCoreProject_CityInfo.Entities;

namespace PluralSightCoreProject_CityInfo.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();

        City GetCity(int cityId, bool includePointsOfInterest);

        IEnumerable<PointOfInterest> GetPointOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
    }
}