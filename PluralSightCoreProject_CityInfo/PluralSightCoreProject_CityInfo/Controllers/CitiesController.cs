using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PluralSightCoreProject_CityInfo.Models;
using PluralSightCoreProject_CityInfo.Services;
using System;
using System.Collections.Generic;

namespace PluralSightCoreProject_CityInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository repository, IMapper mapper)
        {
            _cityInfoRepository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(_cityInfoRepository.GetCities());

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityToReturn = _mapper.Map<CityDto>(city);

                return Ok(cityToReturn);
            }


            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}