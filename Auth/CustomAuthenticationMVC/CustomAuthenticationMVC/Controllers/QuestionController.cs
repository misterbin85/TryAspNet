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
            QuestionViewModel questionViewModel;

            using (AuthenticationDB dB = new AuthenticationDB())
            {
                var questions = dB.Questions.ToList();
                questionViewModel = new QuestionViewModel(questions.First());
            }

            return View("Question", questionViewModel);
        }
    }
}