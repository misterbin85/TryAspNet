using System;
using AutoMapper;
using PluralSightCoreProject_CityInfo.Entities;
using PluralSightCoreProject_CityInfo.Models;

namespace PluralSightCoreProject_CityInfo.Mappers
{
    public class MapperProfile
    {
        public static IMapper Profile = new MapperProfile()._mapper;

        private readonly IMapper _mapper;

        public MapperProfile()
        {
            _mapper = new MapperConfiguration(ex =>
            {
                ex.CreateMap<City, CityWithoutPointsOfInterestDto>();
                ex.CreateMap<City, CityDto>();
                ex.CreateMap<PointOfInterest, PointOfInterestsDto>();
                ex.CreateMap<PointOfInterestsDto, PointOfInterest>();
                ex.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
                ex.CreateMap<PointOfInterestUpdateDto, PointOfInterest>();
                ex.CreateMap<PointOfInterest, PointOfInterestUpdateDto>();
            }).CreateMapper();
        }
    }
}
