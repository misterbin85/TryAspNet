using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using MyTestMVC.DataAccess;
using MyTestMVC.Models;

namespace MyTestMVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Title = "About page contains country Dropdown";
            ViewBag.Message = "Your application description page.";

            var countriesRepo = new StateRepository();
            var regionsRepo = new RegionsRepository();

            var model = new DropdownViewModel
            {
                States = countriesRepo.GetStates(),
                Regions = regionsRepo.GetRegions()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult GetRegions(string state)
        {
            var repo = new RegionsRepository();

            var regions = repo.GetRegions(state);

            return !string.IsNullOrEmpty(state)
                ? Json(regions, JsonRequestBehavior.AllowGet)
                : null;
        }
    }
}