using CustomAuthenticationMVC.DataAccess;
using CustomAuthenticationMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CustomAuthenticationMVC.Controllers
{
	public class QuestionController : Controller
	{
		// GET: Question
		[HttpGet]
		public ActionResult Question()
		{
			List<Question> questions = new List<Question>();
			using (AuthenticationDB dB = new AuthenticationDB())
			{
				questions = dB.Questions.ToList();
			}
			return View("Question", questions.First());
		}
	}
}