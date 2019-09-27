using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PluralSightCoreProject_CityInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == id);

            return cityToReturn != null
                ? (IActionResult)Ok(cityToReturn)
                : NotFound();
        }
    }
}
