using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CustomAuthenticationMVC.DataAccess;
using CustomAuthenticationMVC.Models;

namespace CustomAuthenticationMVC.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
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