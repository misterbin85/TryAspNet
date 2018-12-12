using System.Web.Mvc;

namespace MyTestMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var def = 0;
			//var a = 10 / def;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}