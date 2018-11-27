using MyTestMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyTestMVC.Controllers
{
	public class PeopleController : Controller
	{
		// GET: People
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ListOfPeople()
		{
			List<PersonModel> personModels = new List<PersonModel>
			{
				new PersonModel{FirstName = "Name_1", LastName = "LastName_1"},
				new PersonModel{FirstName = "Name_2", LastName = "LastName_2"},
				new PersonModel{FirstName = "Name_3", LastName = "LastName_3"}
			};

			return View(personModels);
		}
	}
}