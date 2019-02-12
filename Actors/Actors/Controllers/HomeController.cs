using Actors.Repositories;
using System.Web.Mvc;

namespace Actors.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return PartialView();
		}

		public ActionResult Actors()
		{
			var actors = ActorsRepository.GetAllActors();
			return PartialView(actors);
		}

		public ActionResult Actresses()
		{
			return PartialView();
		}

		public ActionResult About()
		{
			return PartialView();
		}
	}
}