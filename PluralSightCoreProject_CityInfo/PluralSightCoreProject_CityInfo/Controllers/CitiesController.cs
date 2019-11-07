using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PluralSightCoreProject_CityInfo.Models;
using PluralSightCoreProject_CityInfo.Services;

namespace PluralSightCoreProject_CityInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository repository)
        {
            _cityInfoRepository = repository;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
           var cities = _cityInfoRepository.GetCities().Select(c => new
            {
                c.Id,
                c.Description,
                c.Name
            });

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
                var cityToReturn = new CityDto
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };
                foreach (var p in city.PointsOfInterest)
                {
                    cityToReturn.PointsOfInterest.Add(new PointOfInterestsDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description
                    });
                }

                return Ok(cityToReturn);
            }

            return Ok(new { city.Id, city.Description, city.Name });
        }
    }
}
