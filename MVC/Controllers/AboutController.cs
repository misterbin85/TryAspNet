using System.Web.Mvc;
using MyTestMVC.DataAccess;
using MyTestMVC.Models;

namespace MyTestMVC.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Title = "About page contains country Dropdown";
            ViewBag.Message = "Your application description page.";

            var countriesRepo = new CountriesRepository();

            var model = new DropdownViewModel
            {
                Countries = countriesRepo.GetCountries()
            };

            return View(model);
        }
    }
}