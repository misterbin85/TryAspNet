using Microsoft.AspNetCore.Mvc;
using PluralSightCoreProject_CityInfo.Entities;

namespace PluralSightCoreProject_CityInfo.Controllers
{
    [ApiController]
    public class DummyController : Controller
    {
        private CityInfoContext cityInfo;

        public DummyController(CityInfoContext cityInfoContext)
        {
            cityInfo = cityInfoContext;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}