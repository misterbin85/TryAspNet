using System.Linq;
using CustomAuthenticationMVC.CustomAuthentication;
using System.Web.Mvc;
using CustomAuthenticationMVC.Models;

namespace CustomAuthenticationMVC.Controllers
{
    [CustomAuthorize(Roles = "Student")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var currentUser = User as CustomPrincipal;
            var model = new CustomSerializeModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                RoleName = currentUser.Roles.ToList(),
                UserId = currentUser.UserId
            };
            return View(model);
        }
    }
}