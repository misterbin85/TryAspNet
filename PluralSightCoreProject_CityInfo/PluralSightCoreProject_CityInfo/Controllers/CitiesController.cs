using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            var cityToReturn = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            
            if (cityToReturn == null)
            {
                return NotFound();
            }

            return includePointsOfInterest 
                ? Ok(cityToReturn) 
                : Ok(new { cityToReturn.Id, cityToReturn.Description, cityToReturn.Name });
        }
    }
}
