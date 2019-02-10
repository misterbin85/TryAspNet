using System.Web.Mvc;
using SPA.Data;

namespace SPA.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult _Index()
        {
            var students = StudentData.GetStudents();
            return PartialView(students);
        }
    }
}